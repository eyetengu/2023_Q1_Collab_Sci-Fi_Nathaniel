using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StationaryPictureElement : MonoBehaviour, IDropHandler
{
    [SerializeField] int compareValue;
    public void OnDrop(PointerEventData eventData)
    {
        
        eventData.pointerDrag.transform.position = transform.position;

        Debug.Log("On Drop: " + eventData.pointerDrag.name);
    }



    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
