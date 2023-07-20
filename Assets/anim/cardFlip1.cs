using UnityEngine;

public class cardFlip1 : MonoBehaviour
{
    public float rotationSpeed = 90f; // Dönüþ hýzý (derece/saniye)
    public float targetRotationY = 90f; // Hedef rotationY deðeri (dönüþ açýsý)

    private bool isRotating = false; // Dönüþ durumunu takip eden bayrak
    private float currentRotationY = 0f; // Mevcut rotationY deðeri
    private float rotationStartTime = 0f; // Dönüþün baþlama zamaný

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
            if (timeSinceStart <= 1f) // Dönüþ süresi (1 saniye) kontrolü
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
