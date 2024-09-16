using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Drop_Payload : MonoBehaviour
{
    [SerializeField] GameObject _payloadObject;
    [SerializeField] Transform _payloadDropPoint;
    [SerializeField] Transform _payloadPouch;
    [SerializeField] bool _isTimed;
    bool _canDrop;
    [SerializeField] int _payloadQuantity;


    private void Start()
    {
        _canDrop = true;
        DropPayload();
    }

    void DropPayload()
    {
        if (_canDrop && _payloadQuantity > 0)
        {
            _payloadQuantity--;
            _canDrop = false;
            
            var payload = Instantiate(_payloadObject, _payloadDropPoint);
            payload.transform.SetParent(_payloadPouch);

            if (_isTimed)
                StartCoroutine(ReloadTimer());
        } 
        else if(_payloadQuantity <= 0)
        {
            _payloadQuantity = 0;
            Debug.Log("Reload");
        }
    }

    IEnumerator ReloadTimer()
    {
        yield return new WaitForSeconds(3.0f);
        _canDrop = true;
        DropPayload();
    }
}
