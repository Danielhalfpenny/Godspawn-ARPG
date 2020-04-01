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
    public Vector3 Scale;

    private GameObject targetObject;
    
    // Start is called before the first frame update
    // Sets shape and its scale.
    void Start()
    {
        switch (shape)
        {
            case Shape.Rectangle:
                targetObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case Shape.Circle:
                targetObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            case Shape.Cone:
                targetObject = GameObject.CreatePrimitive(PrimitiveType.Sphere); // TODO: find a cone shape
                break;
            default:
                Debug.Log("Unknown Shape");
                break;
        }

        
        targetObject.transform.localScale = Scale; 

    }

    // Update is called once per frame
    void Update()
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
    }

    void SetTargetterLocation(Vector3 mouseLocation)
    {
        var r = 0.5; // Todo: collected from player collider. Radius
        var originLocation = origin.transform.position;
        
        // Set working area to (0, 0, 0)
        var workingArea = originLocation - mouseLocation ;

        // Calculate touching points on the circum of the circle collider
        var touchZ = 9 * (r * Math.Cos(-Math.Atan2(workingArea.x, workingArea.z)));
        var touchX = 9 * (r * Math.Sin(-Math.Atan2(workingArea.x, workingArea.z)));

        
        
        var newPos = new Vector3(Convert.ToInt16(touchX), 0, -Convert.ToInt16(touchZ));
        newPos += originLocation;
        targetObject.transform.position = newPos;
        
        Debug.Log(touchX);
        // Debug.Log(touchZ);
   
        targetObject.transform.LookAt(originLocation);
    }
}
