using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public Vector3 rotation;

    
    public 
    // Start is called before the first frame update
    void Start()
    {
        setRotation();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }

    void setRotation()
    {

    }
}
