using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverConMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtenemos la posición del puntero del mouse en el mundo
        Vector3 posicionPuntero = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Mantenemos la misma coordenada Z del objeto para evitar cambios en profundidad
        posicionPuntero.z = transform.position.z;
        // Asignamos la posición al objeto
        transform.position = posicionPuntero;
    }
}
