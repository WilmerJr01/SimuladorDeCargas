using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraRezise : MonoBehaviour
{
    private Vector3 CamaSize;
    private Vector3 camPosition;

    public GameObject objectToFind;
    private string camSize = "camSize";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        objectToFind = GameObject.FindGameObjectWithTag(camSize);
        CamaSize = objectToFind.transform.localScale;
        camPosition = objectToFind.transform.position;
        this.gameObject.transform.localScale = CamaSize; 
        this.gameObject.transform.position = camPosition; 
    }
}
