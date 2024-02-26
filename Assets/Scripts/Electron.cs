using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Electron : MonoBehaviour
{
    private Transform target;
    private Transform iman;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float range;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Mover>().transform;
        iman = FindObjectOfType<Atractor>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= range)
        {
            FleeProt();
        }
        if(Vector3.Distance(iman.position, transform.position) <= range)
        {
            FollowAtrac();
        }

    }
    public void FleeProt()
    {
        transform.position = (Vector3.MoveTowards(transform.position, target.transform.position*-1, speed * Time.deltaTime));
    }

    public void FollowAtrac()
    {
        transform.position = (Vector3.MoveTowards(transform.position, iman.transform.position, speed * Time.deltaTime));
    }
}
