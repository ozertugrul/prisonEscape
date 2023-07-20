using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class missionAnim : MonoBehaviour
{
    public float rotationSpeed = 25f; // D�n�� h�z�
    public float targetRotationY = 0f; // Hedef d�n�� a��s�

    private Quaternion initialRotation; // Ba�lang�� d�n���

    private void Start()
    {
        initialRotation = transform.rotation;
        RotateYToTarget();
    }

    private void OnEnable()
    {
        // Oyun her ba�lad���nda rotationY de�erini 0'a �ek
        RotateYToTarget();
    }

    private void OnDisable()
    {
        // Oyun her sonland���nda rotationY de�erini 90'a �ek
        transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, 90f, initialRotation.eulerAngles.z);
    }

    private void Update()
    {
        if (Mathf.Abs(transform.rotation.eulerAngles.y - targetRotationY) > 0.01f)
        {
            RotateYToTarget();
        }
    }

    private void RotateYToTarget()
    {
        Quaternion targetRotation = Quaternion.Euler(initialRotation.eulerAngles.x, targetRotationY, initialRotation.eulerAngles.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
