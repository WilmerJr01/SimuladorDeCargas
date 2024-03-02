using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovObjNegativo : MonoBehaviour
{
    public float velocidad = 4f; // Velocidad de movimiento
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Definir las teclas personalizadas
        KeyCode teclaIzquierda = KeyCode.A;
        KeyCode teclaDerecha = KeyCode.D;

        // Obtener la entrada del teclado usando las teclas personalizadas
        float movimientoHorizontal = 0f;

        if (Input.GetKey(teclaDerecha))
        {
            movimientoHorizontal = 1f;
        }
        else if (Input.GetKey(teclaIzquierda))
        {
            movimientoHorizontal = -1f;
        }
        // Calcular el desplazamiento basado en la entrada y la velocidad
        Vector3 desplazamiento = new Vector3(movimientoHorizontal, 0, 0) * velocidad * Time.deltaTime;

        // Aplicar el desplazamiento a la posición del objeto
        transform.position += desplazamiento;
    }
}
