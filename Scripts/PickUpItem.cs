using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PickUpItem : MonoBehaviour, IInteractable
{
    public string DisplaySprite;
    public enum property { usable, displayable };
    
    private GameObject InventorySlots;
    //public string DisplayItem;
    //public string CombinationItem;
    public property itemProperty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
    }

    public void ItemPickUp()
    {
        InventorySlots = GameObject.Find("Slots");
        foreach(Transform slot in InventorySlots.transform)
        {
            if(slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite = 
                    Resources.Load<Sprite>("Inventory Items/"+DisplaySprite);
                //slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayItem, CombinationItem);
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty);
                Destroy(gameObject);
                break;
            }
        }
    }
}
