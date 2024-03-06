using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atractor : MonoBehaviour
{
    public GameObject objetoC; // Referencia al objeto C que queremos cambiar su sprite
    public Sprite nuevoSprite; // El nuevo sprite que queremos asignar al objeto C
    public float velocidad = 5f; // Velocidad de movimiento
    public GameObject objetoBPrefab; // Referencia al Prefab del objeto B

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
        if (other.gameObject.CompareTag("Electron"))
        {
            // Verificar si el objeto C y el nuevo sprite están asignados
            if (objetoC != null && nuevoSprite != null)
            {
                // Cambiar el sprite del objeto C
                SpriteRenderer spriteRendererC = objetoC.GetComponent<SpriteRenderer>();
                if (spriteRendererC != null)
                {
                    spriteRendererC.sprite = nuevoSprite;
                }
                else
                {
                    Debug.LogError("El objeto C no tiene un componente SpriteRenderer adjunto.");
                }
            }
            else
            {
                Debug.LogError("Objeto C o nuevo sprite no asignados en el script del objeto A.");
            }
            // Destruir el objeto A actual
            Destroy(other.gameObject);

            // Instanciar el objeto B en la misma posición y rotación que el objeto A
            Instantiate(objetoBPrefab, other.transform.position, other.transform.rotation);
        }
    }
}
