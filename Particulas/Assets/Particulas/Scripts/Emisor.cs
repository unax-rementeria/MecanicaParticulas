using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Emisor : MonoBehaviour
{
    public GameObject particulaPrefab;
    [Range(0.1f, 20f)]
    public float velocidad = 5f;
    [Range(0.1f, 5f)]
    public float tiempoEntreParticulas = 0.5f;

    private TTL ttlScript; // Referencia al script TTL

    [Range(-1f, 1f)]
    public float Pitch = 0f; // Rotación en el eje X
    [Range(-1f, 1f)]
    public float Yaw = 0f; // Rotación en el eje Y
    [Range(-1f, 1f)]
    public float Roll = 0f; // Rotación en el eje Z

    private float tiempoDesdeUltimaParticula = 0f;


    public bool useRandomAngles = false;

    void Update()
    {
        tiempoDesdeUltimaParticula += Time.deltaTime;

        if (tiempoDesdeUltimaParticula >= tiempoEntreParticulas)
        {
            EmitirParticula();
            tiempoDesdeUltimaParticula = 0f;
        }
    }

    void EmitirParticula()
    {
        GameObject particula = Instantiate(particulaPrefab, transform.position, Quaternion.identity);
        
        Rigidbody rb = particula.GetComponent<Rigidbody>();
        ttlScript = particula.AddComponent<TTL>();

        if (rb != null && !useRandomAngles)
        {
            rb.AddForce(new Vector3( Pitch, Roll, Yaw) * velocidad, ForceMode.Impulse); 
        }

        if (rb != null && useRandomAngles)
        {
            float randomPitch = Random.Range(-1f, 1f);
            float randomYaw = Random.Range(-1f, 1f);    
            float randomRoll = Random.Range(-1f, 1f);
            
            rb.AddForce(new Vector3(randomPitch, randomYaw, randomRoll) * velocidad, ForceMode.Impulse);
        }
    }
}
