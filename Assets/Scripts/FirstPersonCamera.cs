using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100.0f; // Mouse sensitivity for camera movement
    public Transform target; // The player object

    private float xRotation = 0.0f; // Current x-axis rotation of the camera

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); // Limit vertical camera movement

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        target.Rotate(Vector3.up * mouseX);
    }
}
