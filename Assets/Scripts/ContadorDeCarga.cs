using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorDeCarga : MonoBehaviour
{
    public List<Transform> hijos = new List<Transform>();
    public float Carga;

    void Start()
    {
        Carga = 0f;
        // Obtener todos los hijos del objeto y agregarlos a la lista
        foreach (Transform hijo in transform)
        {
            hijos.Add(hijo);
        }
    }

    void Update()
    {
        // Calcular la posición del centro del padre
        Vector3 centroPadre = transform.position;

        // Mover todos los hijos hacia el centro del padre
        foreach (Transform hijo in hijos)
        {
            // Excluir el propio objeto padre
            if (hijo == transform)
                continue;

            // Mover el hijo hacia el centro del padre
            hijo.position = centroPadre;
        }
    }
}
