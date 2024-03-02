using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Electron1 : MonoBehaviour
{
    private Transform iman;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float range;

    // Start is called before the first frame update
    void Start()
    {
        iman = FindObjectOfType<Atractor>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(iman.position, transform.position) <= range)
        {
            FollowAtrac();
        }

    }

    public void FollowAtrac()
    {
        transform.position = (Vector3.MoveTowards(transform.position, iman.transform.position, speed * Time.deltaTime));
    }
}
