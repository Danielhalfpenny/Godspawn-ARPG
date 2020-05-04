using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private bool fired ;
    private bool moving ;
    private float forceMult = 35;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fired)
        {
            transform.rotation = GameObject.Find("Player").transform.rotation;
            moving = true;
            fired = false;
        }
        else if (moving)
        {
            transform.parent = null;
            rb.AddForce(transform.forward * forceMult);
        }
    }

    public void Fire()
    {
        fired = true;
    }
}
