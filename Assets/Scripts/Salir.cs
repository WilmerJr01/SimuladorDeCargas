using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    // Start is called before the first frame update
    public void Cerrar()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
