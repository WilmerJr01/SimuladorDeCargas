using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoloATierra : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Definir las teclas personalizadas
        KeyCode teclaArriba = KeyCode.I; // 'W' para mover hacia arriba
        KeyCode teclaAbajo = KeyCode.K; // 'S' para mover hacia abajo

        // Obtener la entrada del teclado usando las teclas personalizadas
        float movimientoVertical = 0f;

        if (Input.GetKey(teclaArriba))
        {
            movimientoVertical = 1f;
        }
        else if (Input.GetKey(teclaAbajo))
        {
            movimientoVertical = -1f;
        }
        // Calcular el desplazamiento basado en la entrada y la velocidad
        Vector3 desplazamiento = new Vector3(0, movimientoVertical, 0) * velocidad * Time.deltaTime;

        // Aplicar el desplazamiento a la posición del objeto
        transform.position += desplazamiento;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si el objeto que colisionó tiene una etiqueta específica
        if (other.gameObject.CompareTag("Barrera"))
        {
            // Si el objeto colisionado tiene la etiqueta "ObjetoB", destruimos ese objeto
            Destroy(other.gameObject); // Destruye el objeto con el que hemos colisionado (Objeto B)
        }
    }
}
