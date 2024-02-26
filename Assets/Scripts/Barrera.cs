using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si el objeto que colision� tiene una etiqueta espec�fica
        if (other.gameObject.CompareTag("PoloTierra"))
        {
            // Si el objeto colisionado tiene la etiqueta "ObjetoB", destruimos este objeto
            Destroy(gameObject); // Destruye el objeto al que est� conectado este script (Objeto A)
        }
    }
}
