using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjeto1 : MonoBehaviour
{
    // Función para sincronizar la posición de todos los hijos con la posición del objeto padre
    public List<Transform> hijos = new List<Transform>();
    public ContadorDeCarga contadorDeCarga;
    public Transform Barrera;
    public GameObject objetoQueCambiaColor; // El objeto cuyo color cambiará
    private bool estaColisionando= false; // Indica si el objeto está colisionando con el otro
    private float tiempoTranscurrido;
    public float tiempoEntreEntregas = 3f; // Tiempo entre entregas de hijos

    void Start()
    {
        // Itera sobre todos los hijos del objeto padre y los agrega a la lista
        foreach (Transform hijo in transform)
        {
            hijos.Add(hijo);
        }
    }

    void Update()
    {
        foreach (Transform hijo in hijos) {
            hijo.position = transform.position;
        }
        if (estaColisionando)
        {
            // Incrementar el tiempo transcurrido
            tiempoTranscurrido += Time.deltaTime;

            // Calcular el factor de cambio de color (entre 0 y 1) basado en el tiempo transcurrido
            float factorCambioColor = Mathf.Clamp01(tiempoTranscurrido / 30f); // 30 segundos para que sea completamente amarillo

            // Cambiar el color del objeto gradualmente a medida que pasa el tiempo
            objetoQueCambiaColor.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.yellow, factorCambioColor);

            // Si ha pasado el tiempo límite, detener el cambio de color
            if (tiempoTranscurrido >= 30f)
            {
                estaColisionando = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Barrera"))
        {
            estaColisionando = true;
            // Iniciar la entrega de hijos cada cierto tiempo
            InvokeRepeating("EntregarHijoABarrera", tiempoEntreEntregas, tiempoEntreEntregas);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Barrera"))
        {
            estaColisionando = false;
            // Detener la entrega de hijos cuando deja de haber colisión
            CancelInvoke("EntregarHijoABarrera");
        }
    }

    void EntregarHijoABarrera()
    {
        if (estaColisionando && hijos.Count > 0)
        {
            // Mover el primer hijo de la lista a la posición de la "Barrera"
            hijos[0].position = Barrera.position;
                // Establece el nuevo padre del primer hijo como la "Barrera"
            hijos[0].parent = Barrera;

            contadorDeCarga.hijos.Add(hijos[0]);

                // Elimina el primer hijo de la lista
            hijos.RemoveAt(0);

                // Incrementa el contador de carga
            contadorDeCarga.Carga= contadorDeCarga.Carga + 5f;
        }
    }
}

