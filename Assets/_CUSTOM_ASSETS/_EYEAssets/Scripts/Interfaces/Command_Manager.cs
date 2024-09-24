using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Command_Manager : MonoBehaviour
{
    private static Command_Manager _instance;
    public static Command_Manager Instance
    {
        get 
        { 
            if (_instance == null)
                Debug.LogError("Command Manager is null");
            
            return _instance;
        }
    }

    private List<ICommand> _commandBuffers = new List<ICommand>();


    private void Awake()
    {
        _instance = this;
    }
    
    public void AddCommands(ICommand command)
    {
        _commandBuffers.Add(command);
    }

    public void PlayCommands()
    {
        StartCoroutine(PlayRoutine());
    }

    IEnumerator PlayRoutine()
    {
        Debug.Log("Playing...");
        foreach(var command in _commandBuffers)
        {
            command.Execute();
            yield return new WaitForSeconds(1.0f);
        }

    }

    public void RewindCommands()
    {
        StartCoroutine(RewindTime());
    }

    IEnumerator RewindTime()
    {
        foreach(var command in Enumerable.Reverse(_commandBuffers))
        {
            command.Undo();
            yield return new WaitForSeconds(1.0f);
        }
    }

    void FinishedCommands()
    {

    }

    public void ResetCommands()
    {
        _commandBuffers.Clear();
    }

    public void Done()
    {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach(var cube in cubes)
        {
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

}
