using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento

    void Update()
    {
        // Obtener la entrada del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el desplazamiento basado en la entrada y la velocidad
        Vector3 desplazamiento = new Vector3(movimientoHorizontal, movimientoVertical, 0) * velocidad * Time.deltaTime;

        // Aplicar el desplazamiento a la posición del objeto
        transform.position += desplazamiento;
    }
}
