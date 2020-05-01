using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{

    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;
    public float smooth = 10.0f;
    private Vector3 dollyDirection;
    public float zoomSpeed = 0.5f;
    public float maxZoom = 7.0f, minZoom = 1.0f;

    private float distance;

    private void Awake()
    {
        dollyDirection = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (maxDistance != maxZoom)
            {
                maxDistance += zoomSpeed;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (maxDistance != minZoom)
            {
                maxDistance -= zoomSpeed;
            }
        }
        
        Vector3 desiredCamPosition = transform.parent.TransformPoint(dollyDirection * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCamPosition, out hit))
        {
            distance = Mathf.Clamp((hit.distance * 0.8f), minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }

        transform.localPosition =
            Vector3.Lerp(transform.localPosition, dollyDirection * distance, Time.deltaTime * smooth);
    }
}
