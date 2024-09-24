using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovablePictureElement : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Image image;
    [SerializeField] int dragCompareValue;

    Vector3 _oldPosition;


//EVENT HANDLERS
    public void OnBeginDrag(PointerEventData eventData)
    {
    //Image Color
        var tempColor = image.color;
        tempColor.a = 0.5f;
        image.color = tempColor;

    //Raycast Target
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {               
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    //Image Color
        var tempColor = image.color;
        tempColor.a = 1.0f;
        image.color = tempColor;

    //Raycast Target
        image.raycastTarget = true;
        ResetPosition();
    }


//BUILT-IN FUNCTIONS
    void Start()
    {
        image = GetComponent<Image>();
        _oldPosition = image.rectTransform.localPosition;
        Debug.Log("Old Position: " + _oldPosition);
    }
    
    void ResetPosition()
    {
        image.rectTransform.localPosition = _oldPosition;
    }
}
