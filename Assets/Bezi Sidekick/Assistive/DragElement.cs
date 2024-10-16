using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragElement : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Image image;
    [SerializeField] int _dragValue;
    [SerializeField] Transform _moveableImagesZone;

    Vector3 _oldPosition;


//PROPERTIES
    public int DragValue { get => _dragValue; }


//BUILT-IN FUNCTIONS
    void Start()
    {
        image = GetComponent<Image>();
        _oldPosition = image.rectTransform.localPosition;
        Debug.Log("Old Position: " + _oldPosition);
    }


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
        Debug.Log("Drag Ended");
        //Image Color
        var tempColor = image.color;
        tempColor.a = 1.0f;
        image.color = tempColor;

    //Raycast Target
        image.raycastTarget = true;
        //ResetPosition();                
    }


//RESET POSITION
    void ResetPosition()//or maybe reset parent instead
    {
        image.rectTransform.localPosition = _oldPosition;
        //transform.SetParent(_moveableImagesZone);        
    }
}
