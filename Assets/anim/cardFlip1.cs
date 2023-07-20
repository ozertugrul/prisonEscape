using UnityEngine;

public class cardFlip1 : MonoBehaviour
{
    public float rotationSpeed = 90f; // D�n�� h�z� (derece/saniye)
    public float targetRotationY = 90f; // Hedef rotationY de�eri (d�n�� a��s�)

    private bool isRotating = false; // D�n�� durumunu takip eden bayrak
    private float currentRotationY = 0f; // Mevcut rotationY de�eri
    private float rotationStartTime = 0f; // D�n���n ba�lama zaman�

    private void OnMouseDown()
    {
        if (!isRotating)
        {
            isRotating = true;
            rotationStartTime = Time.time;
        }
    }

    private void Update()
    {
        if (isRotating)
        {
            float timeSinceStart = Time.time - rotationStartTime;
            if (timeSinceStart <= 1f) // D�n�� s�resi (1 saniye) kontrol�
            {
                currentRotationY = Mathf.Lerp(0f, targetRotationY, timeSinceStart);
                transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);
            }
            else
            {
                currentRotationY = targetRotationY;
                transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);
                isRotating = false;
            }
        }
    }
}
