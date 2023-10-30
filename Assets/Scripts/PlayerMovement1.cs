using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 2.0f; // Чувствительность мыши
    public Transform player;
    private float verticalRotation = 0;
    private float horizontalRotation = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        horizontalRotation += mouseX;

        // Поворачиваем камеру вверх и вниз
        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Поворачиваем игрока влево и вправо
        player.transform.localRotation = Quaternion.Euler(0, horizontalRotation, 0);
    }
}