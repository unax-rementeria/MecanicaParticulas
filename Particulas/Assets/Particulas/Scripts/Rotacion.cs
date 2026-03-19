using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float velocidadAngular = 100f; 
    

    void Update()
    {
        // Rotar el objeto alrededor del eje Y
        transform.Rotate(Vector3.up, velocidadAngular * Time.deltaTime);
        transform.Rotate(Vector3.forward, velocidadAngular * Time.deltaTime);
        transform.Rotate(Vector3.right, velocidadAngular * Time.deltaTime);

    }
}
