using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Emisor : MonoBehaviour
{
    public GameObject particulaPrefab;
    public GameObject particulaPrefabRotar;
    [Range(0.1f, 20f)]
    public float velocidad = 5f;
    [Range(0.1f, 5f)]
    public float tiempoEntreParticulas = 0.5f;

    private TTL ttlScript; // Referencia al script TTL
    private Rotacion rotacionScript; // Referencia al script Rotacion

    [Range(-1f, 1f)]
    public float Pitch = 0f; // Rotación en el eje X
    [Range(-1f, 1f)]
    public float Yaw = 0f; // Rotación en el eje Y
    [Range(-1f, 1f)]
    public float Roll = 0f; // Rotación en el eje Z

    private float tiempoDesdeUltimaParticula = 0f;


    public bool useRandomOffset = false;

    private float randomOffsetX = 0f;
    private float randomOffsetY = 0f;
    private float randomOffsetZ = 0f;


    public bool useAllRandomAngles = false;

    public bool particulasNormales = true;
    public bool particulasRotar = true;



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
        if (particulasNormales)
        {
            GameObject particula = Instantiate(particulaPrefab, transform.position , Quaternion.identity);
            Rigidbody rb = particula.GetComponent<Rigidbody>();
            ttlScript = particula.AddComponent<TTL>();
            if (rb != null && !useAllRandomAngles)
            {
                if(useRandomOffset)
                {
                    randomOffsetX = Random.Range(-0.5f, 0.5f);
                    randomOffsetY = Random.Range(-0.5f, 0.5f);
                    randomOffsetZ = Random.Range(-0.5f, 0.5f);
                }else if (!useRandomOffset)
                {
                    randomOffsetX = 0f;
                    randomOffsetY = 0f;
                    randomOffsetZ = 0f;
                }
                if (particulasNormales)
                {
                    rb.AddForce(new Vector3(Pitch + randomOffsetX, Roll + randomOffsetY, Yaw + randomOffsetZ) * velocidad, ForceMode.Impulse);
                }
            }
            if (rb != null && useAllRandomAngles)
            {
                float randomPitch = Random.Range(-1f, 1f);
                float randomYaw = Random.Range(-1f, 1f);    
                float randomRoll = Random.Range(-1f, 1f);
                if (particulasNormales)
                {
                    rb.AddForce(new Vector3(randomPitch, randomYaw, randomRoll) * velocidad, ForceMode.Impulse);
                }
            }
        }
        
        
        if (particulasRotar)
        {
            GameObject particulaRotar = Instantiate(particulaPrefabRotar, transform.position, Quaternion.identity);
            Rigidbody rbRotar = particulaRotar.GetComponent<Rigidbody>();
            ttlScript = particulaRotar.AddComponent<TTL>();
            rotacionScript = particulaRotar.AddComponent<Rotacion>();

            if (rbRotar != null && !useAllRandomAngles)
            {
                if(useRandomOffset)
                {
                    randomOffsetX = Random.Range(-0.5f, 0.5f);
                    randomOffsetY = Random.Range(-0.5f, 0.5f);
                    randomOffsetZ = Random.Range(-0.5f, 0.5f);
                }else if (!useRandomOffset)
                {
                    randomOffsetX = 0f;
                    randomOffsetY = 0f;
                    randomOffsetZ = 0f;
                }
                if (particulasRotar)
                {
                    rbRotar.AddForce(new Vector3(Pitch + randomOffsetX, Roll + randomOffsetY, Yaw + randomOffsetZ) * velocidad, ForceMode.Impulse); 
                }
            }
            if (rbRotar != null && useAllRandomAngles)
            {
                float randomPitch = Random.Range(-1f, 1f);
                float randomYaw = Random.Range(-1f, 1f);    
                float randomRoll = Random.Range(-1f, 1f);
                if(particulasRotar)
                {
                    rbRotar.AddForce(new Vector3(randomPitch, randomYaw, randomRoll) * velocidad, ForceMode.Impulse);
                }
            }
        }
    }
}
