using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float rotationSpeed = 90f; // degrees per second

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}
