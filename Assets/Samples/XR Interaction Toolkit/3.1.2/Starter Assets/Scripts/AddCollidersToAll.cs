using UnityEngine;

public class AddCollidersToAll : MonoBehaviour
{
    [ContextMenu("Tüm Nesnelere Collider Ekle")]
    void AddColliders()
    {
        // Sahnedeki tüm MeshRenderer'lý nesneleri bul
        MeshRenderer[] allObjects = FindObjectsOfType<MeshRenderer>();

        foreach (MeshRenderer obj in allObjects)
        {
            // Zaten collider varsa atla
            if (obj.GetComponent<Collider>() != null)
                continue;

            // Box Collider ekle (çoðu nesne için yeterli)
            obj.gameObject.AddComponent<BoxCollider>();

            Debug.Log($"Collider eklendi: {obj.name}");
        }
    }
}