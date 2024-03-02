using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjeto1 : MonoBehaviour
{
    // Función para sincronizar la posición de todos los hijos con la posición del objeto padre
    public List<Transform> hijos = new List<Transform>();
    public ContadorDeCarga contadorDeCarga;
    public Transform Barrera;
    public GameObject objetoQueCambiaColor;
    public Color color; // El objeto cuyo color cambiará
    private bool estaColisionando= false; // Indica si el objeto está colisionando con el otro
    private float tiempoTranscurrido= 0f;
    public float tiempoEntreEntregas = 3f; // Tiempo entre entregas de hijos
    private float factorCambioColor;

    void Start()
    {
        // Itera sobre todos los hijos del objeto padre y los agrega a la lista
        foreach (Transform hijo in transform)
        {
            hijos.Add(hijo);
        }
            color = objetoQueCambiaColor.GetComponent<Renderer>().material.color;
        
    }

    void Update()
    {
        
        foreach (Transform hijo in hijos) {
            hijo.position = transform.position;
        }
        if (estaColisionando)
        {
            tiempoTranscurrido += Time.deltaTime;
            factorCambioColor = Mathf.Clamp01(tiempoTranscurrido / 30f);
            objetoQueCambiaColor.GetComponent<Renderer>().material.color = Color.Lerp(color, Color.red, factorCambioColor);

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
            Debug.LogError("Es verdad");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Barrera"))
        {
            estaColisionando = false;
            // Detener la entrega de hijos cuando deja de haber colisión
            CancelInvoke("EntregarHijoABarrera");
            Debug.LogError("Es Falso");
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

