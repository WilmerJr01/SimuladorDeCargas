using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarMetodo : MonoBehaviour
{
    public void CambiarEscena(string Name)
    {
        SceneManager.LoadScene(Name);

    }
}
