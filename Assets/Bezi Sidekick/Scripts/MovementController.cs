using System.Collections;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float _hoverHeight;
    [SerializeField] float _hoverSpeed;
    [SerializeField] float _hoverDelay;

    bool _raising;

    private void Update()
    {
        if(transform.position.y < _hoverHeight && _raising == false)
        {
            _raising = true ;
        }

        if (_raising = false)
            StartCoroutine(HoverTimer());
    }


    IEnumerator HoverTimer()
    {
        yield return new WaitForSeconds(_hoverDelay);

    }
}