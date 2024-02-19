using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentarTamaño : MonoBehaviour
{
    public float incrementoDeEscalaPorSegundo = 0.0000001f;
    public float tiempoDeEspera = 0.005f;
    public bool detenerCrecimiento= false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Obtener el componente SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Iniciar la corrutina para escalar el sprite
        StartCoroutine(AumentarEscalaPorSegundo());
    }

private IEnumerator AumentarEscalaPorSegundo()
    {
        while (!detenerCrecimiento)
        {

            // Incrementar la escala del sprite
            transform.localScale += new Vector3(incrementoDeEscalaPorSegundo, incrementoDeEscalaPorSegundo, 0);


            if (transform.localScale.x >= 4f)
            {
                detenerCrecimiento = true; // Detener el crecimiento
            }

            // Esperar 1 segundo antes de continuar
            yield return new WaitForSeconds(tiempoDeEspera);
        }
    }

}
