using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si el objeto que colisionó tiene una etiqueta específica
        if (other.gameObject.CompareTag("PoloTierra"))
        {
            // Si el objeto colisionado tiene la etiqueta "ObjetoB", destruimos este objeto
            Destroy(gameObject); // Destruye el objeto al que está conectado este script (Objeto A)
        }
    }
}
