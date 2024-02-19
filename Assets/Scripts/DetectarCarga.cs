using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DetectarCarga : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de acercamiento

    private Transform proton; // Referencia al objeto "proton"
    private Vector2 objetivo; // Posición objetivo hacia la que se moverá "proton"

    void Start()
    {
        // Obtener la referencia al objeto "proton" en el inicio
        proton = transform.Find("Proton");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Verificar si el objeto detectado tiene el tag adecuado (si es necesario)
        if (other.CompareTag("CargaNegativa"))
        {
            // Obtener la posición del objeto que está colisionando
            Vector3 posicionObjetoColisionando = other.transform.position;

            // Mantener la coordenada Z de la posición objetivo
            objetivo = new Vector2(posicionObjetoColisionando.x, posicionObjetoColisionando.y);
        }
    }

    void Update()
    {
        // Mover "proton" gradualmente hacia la posición objetivo
        proton.position = Vector2.Lerp(proton.position, objetivo, velocidad * Time.deltaTime);
    }
}
