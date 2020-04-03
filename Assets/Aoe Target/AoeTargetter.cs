using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AoeTargetter : MonoBehaviour
{
    public enum Shape { Rectangle, Circle, Cone }
    public Shape shape;
    public GameObject origin;
    public float width, length;
    public float speed;
    
    private bool isTargetting;
    private GameObject targetObject;
    
    // Start is called before the first frame update
    // Sets shape and its scale.
    void Start()
    {
        switch (shape)
        {
            case Shape.Rectangle:
                targetObject = Instantiate(Resources.Load("Rectangle Targetter", typeof(GameObject)) as GameObject);
                break;
            case Shape.Circle:
                targetObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            case Shape.Cone:
                targetObject = Instantiate(Resources.Load("Rectangle Targetter") as GameObject);// TODO: find a cone shape
                break;
            default:
                Debug.Log("Unknown Shape");
                break;
        }

        isTargetting = true;
        targetObject.transform.localScale = new Vector3(width, 0.01f, length); 

    }

    // Update is called once per frame
    void Update()
    {

        if (isTargetting)
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                    SetTargetterLocation(hit.point);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                var pos = Activate();
                Debug.Log(pos);
                StopTargeting();
            }
        }
    }

    // Returns target's location
    Vector3 Activate()
    {
        return targetObject.transform.position;
    }

    // Removes the target and the Targetter entity
    void StopTargeting()
    {
        Destroy(targetObject);
        Destroy(gameObject);
        isTargetting = false;
    }

    void SetTargetterLocation(Vector3 mouseLocation)
    {
        var newPos = origin.transform.position;
        targetObject.transform.position = newPos;

        var lookPos = mouseLocation - targetObject.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        targetObject.transform.rotation = Quaternion.Slerp(targetObject.transform.rotation, rotation, Time.deltaTime * speed);
    }
}
