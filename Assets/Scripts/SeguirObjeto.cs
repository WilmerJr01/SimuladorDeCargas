using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjeto : MonoBehaviour
{
    // Función para sincronizar la posición de todos los hijos con la posición del objeto padre
    public List<Transform> hijos = new List<Transform>();
    public ContadorDeCarga contadorDeCarga;
    public Transform Barrera;

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Barrera"))
        {
            if (hijos.Count > 0)
            {
                // Mueve el primer hijo de la lista a la posición de la "Barrera"
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
}

