using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float xSensitivity = 10f, ySensitivity = 10f;

    [SerializeField] private Camera playerCamera;
    private float xRotation, yRotation;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x * Time.deltaTime * xSensitivity, mouseY = input.y * Time.deltaTime * ySensitivity;
        
        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
