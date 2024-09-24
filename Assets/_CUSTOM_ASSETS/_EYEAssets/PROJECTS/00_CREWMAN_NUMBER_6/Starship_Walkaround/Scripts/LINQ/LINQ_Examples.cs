using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



[System.Serializable]
public class Item
{
    public string _name;
    public int _id;
    public int _buff;
}



public class LINQ_Examples : MonoBehaviour
{
    [SerializeField] string[] _names = { "jon", "mary", "max", "jon", "max", "tysone" };

    public List<Item> items = new List<Item>();

    void Start()
    {
    }

    void Update()
    {
        //AnyFunction();
        //ContainsFunction();
        //DistinctFunction();
        //WhereFunction();
        //OrderByDescending();
        //FilteringItems();
    }


    void AnyFunction()
    {
        //returns a bool
        var anyNameFound = _names.Any(name => name == "jon");
        Debug.Log("Name Found: " + anyNameFound);
        var anyNameFound1 = _names.Any(name => name == "maxx");
        Debug.Log("Name Found: " + anyNameFound1);
    }

    void ContainsFunction()
    {
        //returns a bool
        var containsName = _names.Contains("jon");
        Debug.Log("Contains Name 'Jon': " + containsName);
    }

    void DistinctFunction()
    {
        //Returns a List<string>
        var distinctNameFound = _names.Distinct();
        foreach(var n in distinctNameFound)
        {
            Debug.Log("Name: " + n);
        }
    }

    void WhereFunction()
    {
        //Returns a List<string>
        var result = _names.Where(n => n.Length > 3);
        foreach (var n in result)
            Debug.Log("Name: " + n);
        
    }

    void OrderByDescending()
    {
        //Returns a List<string>
        var descendingOrder = _names.Where(n => n.Length >= 3).OrderByDescending(n => n);
        foreach(var item in descendingOrder)
            Debug.Log("Name: " + item);
    }

    void FilteringItems()
    {
        var itemToFind01 = items.Where(name => name._id == 3);
        var listofThem = "";
        foreach (var item in itemToFind01)
            listofThem += item._name;
        Debug.Log("Item 01: " + listofThem);

        var itemsOver19 = items.Where(name => name._buff > 19);
        var message = "";
        foreach (var item in itemsOver19)
            message += item._name + "\n";
        Debug.Log("Items 02: " + message);

        var averageBuff = items.Where(name => name._buff > 0);
        var total = 0;
        var buffCount = 0;
        foreach (var amt in averageBuff)
        {
            buffCount++;
            total += amt._buff;
        }
        Debug.Log("Items 03: " + total/buffCount);
    }




}

