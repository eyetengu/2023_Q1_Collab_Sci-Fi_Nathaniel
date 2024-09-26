using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropElement : MonoBehaviour, IDropHandler
{
    [SerializeField] int _dropValue;
    UI_Score_DRAGDROP _uiManager;

    //public int DropValue { get => _dropValue; }


    void Start()
    {
        _uiManager = FindObjectOfType<UI_Score_DRAGDROP>();
        //Debug.Log("DropValue: " + DropValue);
    }

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.transform.position = transform.position;
        var let = eventData.pointerDrag.GetComponent<DragElement>();
        var let2 = let.GetComponent<DragElement>();
        if (let != null)
        {
            if (let2.DragValue == _dropValue)
            {
                Debug.Log("We Have A Match Folks");
                eventData.pointerDrag.transform.position = transform.position;
                _uiManager.Score();
                //eventData.pointerDrag.gameObject.GetComponent<Image>().color = Color.green;

            }
            else
            {
                //eventData.pointerDrag.gameObject.GetComponent<Image>().color = Color.red;
            }
            Debug.Log("KO");
            Debug.Log("On Drop: " + eventData.pointerDrag.name);
        }
    }
}
