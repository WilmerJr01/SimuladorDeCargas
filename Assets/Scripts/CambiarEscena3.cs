using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena3 : MonoBehaviour
{
    // Start is called before the first frame update
    public void CambiarEscenas()
    {
        SceneManager.LoadScene("Contacto");
    }

}
