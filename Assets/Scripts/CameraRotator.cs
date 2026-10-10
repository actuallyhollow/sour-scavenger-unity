using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotationSpeed = 15.0F;
    
    void Update()
    {
        this.transform.Rotate(Vector3.up, this.rotationSpeed * Time.deltaTime, Space.World);
    }
}