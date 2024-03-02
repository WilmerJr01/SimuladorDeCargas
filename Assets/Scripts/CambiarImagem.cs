using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarImagem : MonoBehaviour
{
    public Image imagen;
    public bool Switch;

    // Referencias a las imágenes que quieres intercambiar
    public Sprite nuevaImagen1;
    public Sprite nuevaImagen2;
    public GameObject Trapo;
    public GameObject Linterna;

    void Start()
    {
        Switch = true;
        // Asegúrate de que la referencia a la imagen esté establecida
    }

    // Método para cambiar la imagen cuando se hace clic en ella
    public void Cambiar()
    {
        // Aquí puedes alternar entre las imágenes según tu lógica
        // Por ejemplo, si la imagen actual es nuevaImagen1, cámbiala a nuevaImagen2 y viceversa
        if (imagen.sprite == nuevaImagen1)
        {
            imagen.sprite = nuevaImagen2;
            Switch= false;
            Linterna.SetActive(true);
            Trapo.SetActive(false);
        }
        else
        {
            imagen.sprite = nuevaImagen1;
            Switch = true;
            Linterna.SetActive(false);
            Trapo.SetActive(true);
        }
    }
}
