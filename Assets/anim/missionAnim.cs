using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class missionAnim : MonoBehaviour
{
    public float rotationSpeed = 25f; // Dönüþ hýzý
    public float targetRotationY = 0f; // Hedef dönüþ açýsý

    private Quaternion initialRotation; // Baþlangýç dönüþü

    private void Start()
    {
        initialRotation = transform.rotation;
        RotateYToTarget();
    }

    private void OnEnable()
    {
        // Oyun her baþladýðýnda rotationY deðerini 0'a çek
        RotateYToTarget();
    }

    private void OnDisable()
    {
        // Oyun her sonlandýðýnda rotationY deðerini 90'a çek
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
