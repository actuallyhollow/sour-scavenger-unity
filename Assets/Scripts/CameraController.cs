using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private float mouseSensitivity = 0.5F;
    [SerializeField] private Transform playerBody;
    [SerializeField] private InputAction lookAction = new InputAction(type: InputActionType.Value, binding: "<Mouse>/delta");

    private float xRotation = 0.0F;

    void OnEnable()
    {
        this.lookAction.Enable();
    }

    void OnDisable()
    {
        this.lookAction.Disable();
    }

    void Update()
    {
        Vector2 lookInput = this.lookAction.ReadValue<Vector2>();
        float mouseX = lookInput.x * this.mouseSensitivity;
        float mouseY = lookInput.y * this.mouseSensitivity;

        this.xRotation -= mouseY;
        this.xRotation = Mathf.Clamp(this.xRotation, -90.0F, 90.0F);
        this.transform.localRotation = Quaternion.Euler(this.xRotation, 0.0F, 0.0F);

        if(this.playerBody != null)
        {
            this.playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}