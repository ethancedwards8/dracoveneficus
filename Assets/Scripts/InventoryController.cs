using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [SerializeField] List<string> inventory;
    [SerializeField] List<string> itemDesc;

    //\\--------------------------------------------------------\\//
    void Start()
    {
        AddItem("banana", "potassium");
        AddItem("wabbajack", "it's all you've got");

        RemoveItem(0);

        ListInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//\\--------------------------------------------------------\\//

    void AddItem(string item, string description)        //adds item
    {
        inventory.Add(item);
        itemDesc.Add(description);
    }

    void RemoveItem(int itemNum)                    //gets rid of item
    {
        inventory.RemoveAt(itemNum);
        itemDesc.RemoveAt(itemNum);
    }

    void ListInfo(int itemNum)                     //lists description given to item requested
    {
        if (inventory[itemNum] != null)
        {
            Debug.Log(itemDesc[itemNum]);
        }
        else
        {
            Debug.Log("that doesn't exist");
        }
    }
    


}

