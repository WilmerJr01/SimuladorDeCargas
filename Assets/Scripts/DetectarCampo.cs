using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarCampo : MonoBehaviour
{
    public float velocidadDeMovimiento= 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        // Verificar si la colisión es con un objeto que tiene el tag "CampoElectrico"
        
            // Calcular la dirección hacia arriba (en el eje Y)
            Vector3 direccion = Vector3.up;

            // Aplicar una fuerza a la partícula para moverla hacia arriba
            Rigidbody rb = GetComponent<Rigidbody>(); // Suponiendo que la partícula tiene un Rigidbody
            if (rb != null)
            {
                // Cambiar la velocidad de la partícula
                rb.velocity = direccion * velocidadDeMovimiento;
            }
            else
            {
                Debug.LogWarning("El objeto no tiene un Rigidbody adjunto. La partícula no se puede mover.");
            }
        
    }
}
