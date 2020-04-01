using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AoeTargetter : MonoBehaviour
{
    public enum Shape { Rectangle, Circle, Cone }
    public Shape shape;
    
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
                targetObject.transform.position = hit.point;
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
}
