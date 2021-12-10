using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : InventoryController
{
    //enum ItemList {HPOTION, SPOTION, ARROWS, BOW, SKELETON, SWORD, SHIELD}
    // with   100%, 100%, 70%, 10%, 1%, 30%, 40%  chance of spawning respectfully


    [SerializeField] Sprite[] chestSprites;

    bool unlocked = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }




    void Open()
    {
        if (Input.GetMouseButtonDown(0) && unlocked)
        {
            SpriteChange();
            
        }
    }

    void SpriteChange()
    {
        GetComponent<SpriteRenderer>().sprite = chestSprites[1];
    }


}
/// <summary>
/// /https://stackoverflow.com/questions/33888612/how-to-make-selection-random-based-on-percentage
/// </summary>
