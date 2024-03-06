using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarColor : MonoBehaviour
{
    public Image imagen; // Referencia a la imagen que cambiará de color
    public float velocidadCambio = 1f; // Velocidad a la que cambiará el color
    public Color colorInicio = Color.blue; // Color inicial (azul)
    public Color colorFinal = Color.red; // Color final (rojo)

    private bool cambiandoAColorFinal = true; // Indica si está cambiando hacia el color final o no
    private float tiempoInicioCambio; // Tiempo en el que se inició el cambio de color

    void Start()
    {
        // Establecer el color inicial de la imagen
        imagen.color = colorInicio;
        // Guardar el tiempo en el que se inició el cambio de color
        tiempoInicioCambio = Time.time;
    }

    void Update()
    {
        // Calcular el progreso del cambio de color entre 0 y 1
        float progreso = (Time.time - tiempoInicioCambio) * velocidadCambio;
        // Si está cambiando hacia el color final
        if (cambiandoAColorFinal)
        {
            // Cambiar gradualmente el color hacia el color final (rojo)
            imagen.color = Color.Lerp(colorInicio, colorFinal, progreso);
        }
        else
        {
            // Cambiar gradualmente el color hacia el color inicial (azul)
            imagen.color = Color.Lerp(colorFinal, colorInicio, progreso);
        }

        // Si el progreso es mayor o igual a 1, cambiar la dirección del cambio de color
        if (progreso >= 1f)
        {
            cambiandoAColorFinal = !cambiandoAColorFinal;
            // Reiniciar el tiempo de inicio del cambio de color
            tiempoInicioCambio = Time.time;
        }
    }
}
