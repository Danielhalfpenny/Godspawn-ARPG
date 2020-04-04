using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AoeTargetter : MonoBehaviour
{
    public enum Shape { Rectangle, Circle, Cone }
    public Shape shape;
    public float width, length;
    public float speed;
    
    public bool isTargetting;
    private GameObject targetObject;
    private Camera _camera;

    // Update is called once per frame
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
    var ray = _camera.ScreenPointToRay(Input.mousePosition);

    if (!Physics.Raycast(ray, out var hit)) return;
    if (hit.collider is TerrainCollider)
    {
        if (isTargetting)
        {
            SetTargetterLocation(hit.point);
        }
    }

    }

    private void SetTargetterLocation(Vector3 mouseLocation)
    {
        var newPos = transform.parent.gameObject.transform.position; // Origin at parent node
        targetObject.transform.position = newPos;

        var lookPos = mouseLocation - targetObject.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        targetObject.transform.rotation = Quaternion.Slerp(targetObject.transform.rotation, rotation, Time.deltaTime * speed);
    }
    
    
    // Deletes targetter and returns it's rotation
    public Vector3 Activate()
    {
        StopTargeting();
        return targetObject.transform.position + new Vector3(8, 0, 0);
    }
    
    // Removes the target and the Targetter entity
    public void StopTargeting()
    {
        Destroy(targetObject);
        isTargetting = false;
    }
    
    public void StartTargeting()
    {
        switch (shape)
        {
            case Shape.Rectangle:
                targetObject = Instantiate(Resources.Load("Rectangle Targetter", typeof(GameObject)) as GameObject, transform);
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
}
