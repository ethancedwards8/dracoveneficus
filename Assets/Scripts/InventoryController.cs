using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [SerializeField] List<string> inventory;

//\\--------------------------------------------------------\\//
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//\\--------------------------------------------------------\\//

    void AddItem(string item, string description)  //adds item
    {
        inventory.Add(item);
    }

    void RemoveItem(string item)       //gets rid of item
    {
        inventory.Remove(item);
    }

    void ListInfo(int item)               //lists description given to item requested
    {
        if (inventory.Exists(item))
        {
            //Debug.Log();
        }
        else
        {

        }
    }










}
