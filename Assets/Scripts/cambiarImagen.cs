using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cambiarImagen : MonoBehaviour
{
    public Sprite imagenOriginal; // La imagen original que se mostrará al inicio
    public Sprite imagenAlternativa; // La imagen que se mostrará al hacer clic
    private Image imageComponent; // Referencia al componente Image del canvas
    private bool alternarImagen = false; // Variable para alternar entre las imágenes
    public GameObject objeto1;
    public GameObject objeto2;


    void Start()
    {
        // Obtener el componente Image del objeto al que está adjunto el script
        imageComponent = GetComponent<Image>();
        
        // Configurar la imagen original al inicio
        imageComponent.sprite = imagenOriginal;
    }

    // Método para cambiar la imagen al hacer clic en la imagen actual
    public void Cambiar()
    {
        // Alternar entre las imágenes
        alternarImagen = !alternarImagen;

        // Si la variable es verdadera, mostrar la imagen alternativa; de lo contrario, mostrar la imagen original
        if (alternarImagen)
        {
            imageComponent.sprite = imagenAlternativa;
            objeto1.SetActive(true);
            objeto2.SetActive(false);
        }
        else
        {
            imageComponent.sprite = imagenOriginal;
            objeto1.SetActive(false);
            objeto2.SetActive(true);
        }
    }
}
