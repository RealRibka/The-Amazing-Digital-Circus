using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTransform; // ������ �� ��������� ������
    public float rotationSpeed = 2.0f;
    public float maxRotationSpeed = 5.0f; // ������������ �������� �������� ������
    private Vector3 offset;
    private bool rotateCamera = false;

    private void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform not assigned to CameraControl script.");
            enabled = false; // ��������� ������, ����� �������� ������
            return;
        }

        offset = transform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        if (rotateCamera)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                float desiredAngle = playerTransform.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
                transform.position = playerTransform.position + rotation * offset;
                transform.LookAt(playerTransform.position);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rotateCamera = true;
        }
        else
        {
            rotateCamera = false;
        }
    }

    // �������� ���� ����� ��� ����������� �������� �������� ������
    private void ClampRotationSpeed()
    {
        rotationSpeed = Mathf.Clamp(rotationSpeed, 0, maxRotationSpeed);
    }
}