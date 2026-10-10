using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0F;
    [SerializeField] private InputActionReference moveAction;
    
    private Rigidbody rigidbody;
    private Vector3 movementInput;

    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void OnEnable()
    {
        if (moveAction != null) moveAction.action.Enable();
    }

    void OnDisable()
    {
        if (moveAction != null) moveAction.action.Disable();
    }

    void Update()
    {
        if (moveAction == null) return;

        Vector2 inputVector = moveAction.action.ReadValue<Vector2>();

        movementInput = new Vector3(inputVector.x, 0f, inputVector.y);
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocity = movementInput * moveSpeed;
    }
}