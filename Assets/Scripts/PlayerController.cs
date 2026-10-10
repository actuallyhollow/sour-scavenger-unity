using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5.0F;
    [SerializeField] private InputActionReference moveAction;
    
    [Header("Camera Reference")]
    [SerializeField] private Transform cameraTransform;

    private Rigidbody rigidbody;
    private Vector3 moveDirection;

    void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
        
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
    }

    void FixedUpdate()
    {
        this.rigidbody.linearVelocity = new Vector3(
            this.moveDirection.x * this.moveSpeed, 
            this.rigidbody.linearVelocity.y, 
            this.moveDirection.z * this.moveSpeed
        );
    }
}