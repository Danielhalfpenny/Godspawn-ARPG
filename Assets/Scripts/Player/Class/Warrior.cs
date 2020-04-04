using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    private GameObject _targetObj;
    private AoeTargetter _targetScript;
    private CharacterController _characterController;
    
    private bool _isDashing;
    private Vector3 _dashPoint;

    private void Start()
    {
        _targetObj = Instantiate(Resources.Load("Targetter", typeof(GameObject)) as GameObject, transform);
        _targetScript = _targetObj.GetComponent<AoeTargetter>();
        _isDashing = false;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (_isDashing)
        {
            if (transform.position == _dashPoint)
            {
                _isDashing = false;
            }
            transform.position = Vector3.Lerp(transform.position, _dashPoint, 0.01f);
        }
        
        if (Input.GetMouseButtonDown(0))
        { 
            Debug.Log("Shield Charge!");
            shieldCharge();
        }
    }

    private void StopDashing()
    {
        _isDashing = false;
    }
    void shieldCharge()
    {
        _targetScript.length = 8;
        _targetScript.width = 1;
        _targetScript.shape = AoeTargetter.Shape.Rectangle;
        var dashTimer = 0.6f;
        
        if (_targetScript.isTargetting)
        {
            _dashPoint = _targetScript.Activate();
            _isDashing = true; // TODO: Lock player input
            Invoke(nameof(StopDashing), dashTimer);
            Debug.Log(_dashPoint);
        }
        else
        {
            _targetScript.StartTargeting();
        }
    }
}
