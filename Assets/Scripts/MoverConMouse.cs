using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverConMouse : MonoBehaviour
{
    
    // Update is called once per frame

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si se está presionando el botón izquierdo del ratón (o touch en dispositivos táctiles)
        if (Input.GetMouseButton(1))
        {

            // Obtener la posición del cursor en el mundo
            Vector3 posicionCursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Mantener la misma coordenada Z del objeto para evitar cambios en profundidad
            posicionCursor.z = transform.position.z;
            // Asignar la posición al objeto
            transform.position = posicionCursor;
        }
    }
}
