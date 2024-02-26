using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarCarga : MonoBehaviour
{
    private Transform proton; // Referencia al objeto "proton"
    private Vector3 objetivo; // Posición objetivo hacia la que se moverá "proton"
    private Vector3 posicionObjetoColisionando;
    private float CargaDeParticula = 90f;

    void Start()
    {
        // Obtener la referencia al objeto "proton" en el inicio
        proton = transform.Find("Proton (2)");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Verificar si el objeto detectado tiene el tag adecuado (si es necesario)
        if (other.CompareTag("CargaNegativa"))
        {
            // Obtener la posición del objeto que está colisionando
            posicionObjetoColisionando = other.transform.position;

            // Mantener la coordenada Z de la posición objetivo
            objetivo = new Vector3(posicionObjetoColisionando.x, posicionObjetoColisionando.y, -2);
        }
    }

    void Update()
    {
        // Mover "proton" gradualmente hacia la posición objetivo
        if (posicionObjetoColisionando != null)
        {
            // Calcular la distancia entre el "proton" y el objetivo
            float distancia = Vector3.Distance(proton.position, posicionObjetoColisionando);

            // Calcular la velocidad basada en la distancia
            float velocidad = CargaDeParticula / distancia;

            // Limitar la velocidad mínima para evitar divisiones por cero
            velocidad = Mathf.Max(velocidad, 0.1f);

            // Mover "proton" hacia la posición objetivo con la velocidad ajustada
            proton.position = Vector3.MoveTowards(proton.position, objetivo, velocidad * Time.deltaTime);
        }
    }
}
