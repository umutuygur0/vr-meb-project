using UnityEngine;


public class CanvasLookAtPlayer : MonoBehaviour
{
    public Transform playerCamera; // XR Origin içindeki Camera (genelde MainCamera)

    void Update()
    {
        if (playerCamera == null)
        {
            // Eðer kamera atanmadýysa otomatik bul
            playerCamera = Camera.main?.transform;
            if (playerCamera == null) return;
        }

        // Canvas’ý her frame’de kameraya döndür
        transform.LookAt(playerCamera);

        // Canvas’ýn yönünü ters çevirmek gerekebilir (yazýlar ters görünüyorsa)
        transform.Rotate(0, 180, 0);
    }
}
