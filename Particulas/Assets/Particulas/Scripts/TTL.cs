using UnityEngine;

public class TTL : MonoBehaviour
{
    public float TTLPrefab = 0.5f; // Tiempo de vida en segundos

    void Start()
    {
        Destroy(gameObject, TTLPrefab); // Destruye el objeto después de X segundos
    }
}
