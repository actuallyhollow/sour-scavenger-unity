using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5.0F;
    [SerializeField] private float rotationSpeed = 15.0F;
    [SerializeField] private InputActionReference moveAction;
    
    [Header("Camera Reference")]
    [SerializeField] private Transform cameraTransform;

    [Header("Model Reference")]
    [SerializeField] private Transform characterModel;

    [Header("Audio Settings")]
    [SerializeField] private float footstepInterval = 0.5F;

    private Rigidbody rigidbody;
    private Vector3 moveDirection;
    private Animator animator;
    private float footstepTimer;

    void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
        this.animator = this.GetComponentInChildren<Animator>();
        
        if(this.cameraTransform == null && Camera.main != null)
        {
            this.cameraTransform = Camera.main.transform;
        }
    }

    void OnEnable()
    {
        if(this.moveAction != null)
        {
            this.moveAction.action.Enable();
        }
    }

    void OnDisable()
    {
        if(this.moveAction != null)
        {
            this.moveAction.action.Disable();
        }
    }

    void Update()
    {
        if(this.moveAction == null || this.cameraTransform == null)
        {
            return;
        }

        Vector2 inputVector = this.moveAction.action.ReadValue<Vector2>();

        Vector3 cameraForward = this.cameraTransform.forward;
        Vector3 cameraRight = this.cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        this.moveDirection = (cameraForward * inputVector.y + cameraRight * inputVector.x).normalized;

        if(this.animator != null)
        {
            this.animator.SetFloat("Speed", inputVector.magnitude);
        }

        if(this.moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(this.moveDirection);
            this.characterModel.rotation = Quaternion.Slerp(this.characterModel.rotation, targetRotation, this.rotationSpeed * Time.deltaTime);
            this.HandleFootsteps(inputVector.magnitude);
        }
        else
        {
            this.footstepTimer = 0.0F;
        }
    }

    void FixedUpdate()
    {
        this.rigidbody.linearVelocity = new Vector3(
            this.moveDirection.x * this.moveSpeed, 
            this.rigidbody.linearVelocity.y, 
            this.moveDirection.z * this.moveSpeed
        );
    }

    private void HandleFootsteps(float inputMagnitude)
    {
        if(inputMagnitude > 0.1F)
        {
            this.footstepTimer += Time.deltaTime;

            if(this.footstepTimer >= this.footstepInterval)
            {
                if(AudioController.Instance != null)
                {
                    AudioController.Instance.PlayAudio(AudioController.Instance.footstepAudio);
                }
                this.footstepTimer = 0.0F;
            }
        }
        else
        {
            this.footstepTimer = 0.0F;
        }
    }
}