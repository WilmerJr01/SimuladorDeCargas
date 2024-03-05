using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Vector3 camSize;

    // Start is called before the first frame update
    void Start()
    {
        camSize = this.gameObject.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
