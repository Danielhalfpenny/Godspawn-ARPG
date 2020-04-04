using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMovement : MonoBehaviour
{
    private enum MoveType
    {
        line
    }

    private MoveType _moveType;
    private Vector3 _endPoint;
    private float _speed;

    private bool _active;
    
    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if (transform.position.normalized == _endPoint.normalized)
            {
                Destroy(gameObject);
            }
            else
            {
                switch (_moveType)
                {
                    case MoveType.line:
                        transform.position = Vector3.Lerp(transform.position, _endPoint, _speed);
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
           
        }
    }

    public void Firebolt(float speed, Vector3 endPoint)
    {
        _moveType = MoveType.line;
        _speed = speed;
        _endPoint = endPoint;
        _endPoint.y = 2;
        _active = true;
    }
}
