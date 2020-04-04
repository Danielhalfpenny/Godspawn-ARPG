using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    private GameObject _targetObj;
    private AoeTargetter _targetScript;
    private bool _isCasting;
    
    private GameObject _fireboltResource;

    // Start is called before the first frame update
    void Start()
    {
        _isCasting = false;
        _targetObj = Instantiate(Resources.Load("Targetter", typeof(GameObject)) as GameObject, transform);
        _fireboltResource = Resources.Load("Firebolt", typeof(GameObject)) as GameObject;
        _targetScript = _targetObj.GetComponent<AoeTargetter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastFirebolt();
        }
    }

    void CastFirebolt()
    {
        _targetScript.length = 15;
        _targetScript.width = 1;
        _targetScript.shape = AoeTargetter.Shape.Rectangle;
        var yOffset = new Vector3(0, 2, 0);
        
        if (_targetScript.isTargetting)
        { 
            var firebolt_object = Instantiate(_fireboltResource, transform.position + yOffset, Quaternion.identity);
            firebolt_object.GetComponent<SpellMovement>().Firebolt(0.05f,_targetScript.Activate());
        }
        else
        {
            _targetScript.StartTargeting();
        }
    }
}
