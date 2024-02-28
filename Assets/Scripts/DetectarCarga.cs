using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarCarga : MonoBehaviour
{
    private Transform[] hijos; // Referencia a todos los hijos del objeto
private Vector3 objetivo; // Posición objetivo hacia la que se moverán los hijos
private Vector3 posicionObjetoColisionando;
public ContadorDeCarga contadorDeCargas;
private float cargaDeParticula; // La carga de la partícula, ajusta según sea necesario
private float velocidadMaxima; // Velocidad máxima de movimiento

void Start()
{
    // Obtener todos los hijos del objeto
    hijos = GetComponentsInChildren<Transform>();
    // Calcular la velocidad máxima basada en la carga de partícula
    velocidadMaxima = 1000f;
}

void OnTriggerStay2D(Collider2D other)
{
    // Verificar si el objeto detectado tiene el tag adecuado (si es necesario)
    if (other.CompareTag("Barrera"))
    {
        // Obtener la posición del objeto que está colisionando
        posicionObjetoColisionando = other.transform.position;

        // Mantener la coordenada Z de la posición objetivo
        objetivo = new Vector3(posicionObjetoColisionando.x, posicionObjetoColisionando.y, -2);
    }
}


void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Barrera"))
    {
            // Obtener la posición del objeto que está colisionando
            posicionObjetoColisionando = Vector3.zero;
    }
}

void Update()
{
    // Mover todos los hijos gradualmente hacia la posición objetivo o al centro del objeto
    cargaDeParticula = contadorDeCargas.Carga;

    if (posicionObjetoColisionando != Vector3.zero)
    {
        foreach (Transform hijo in hijos)
        {
            // Excluir el propio objeto padre
            if (hijo == transform)
                continue;

            // Calcular la distancia entre el hijo y el objetivo
            float distancia = Vector3.Distance(hijo.position, posicionObjetoColisionando);

            // Calcular la velocidad basada en la distancia
            float velocidad = cargaDeParticula / distancia;

            // Limitar la velocidad máxima
            velocidad = Mathf.Clamp(velocidad, 0f, velocidadMaxima);

            // Mover el hijo hacia la posición objetivo con la velocidad ajustada
            hijo.position = Vector3.MoveTowards(hijo.position, objetivo, velocidad * Time.deltaTime);
        }
    }
    else
    {
        // Si no hay colisión con "Barrera", mover los hijos hacia el centro del objeto
        Vector3 centroObjeto = transform.position;
        foreach (Transform hijo in hijos)
        {
            // Excluir el propio objeto padre
            if (hijo == transform)
                continue;

            // Calcular la dirección hacia el centro del objeto
            Vector3 direccion = (centroObjeto - hijo.position).normalized;

            // Mover el hijo hacia el centro del objeto
            hijo.position += direccion * 1f * Time.deltaTime;
        }
    }
}
}
