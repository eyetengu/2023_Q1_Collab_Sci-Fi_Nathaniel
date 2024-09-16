using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Origin_Quest : MonoBehaviour
{
    [SerializeField] string _questExplainedDialog;

    [SerializeField] public List<GameObject> _todoList;

    [SerializeField] string _questAcceptedDialog;
    [SerializeField] string _questCompletedDialog;
    [SerializeField] GameObject _questRewardObject;
    
    public string RetrieveExplainedDialog           { get => _questExplainedDialog;                 }

    public string RetrieveQuestAcceptedDialog       { get => _questAcceptedDialog;                  }

    public string RetrieveQuestCompleteDialog       { get => _questCompletedDialog;                 }

    public GameObject RetrieveQuestRewardObject     { get => _questRewardObject;                    }

    public List<GameObject> RetrieveTodoList        { get => _todoList; set => _todoList = value;   }
}
