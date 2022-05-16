using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }
    private GameObject slots;
    //public GameObject itemDisplayer { get; private set; }
    public GameObject initialEmptySlot;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        SelectSlot();
        //HideDisplay();
    }

    void InitializeInventory(){
       slots = GameObject.Find("Slots");
       //itemDisplayer = GameObject.Find("ItemDisplayer");
       //itemDisplayer.SetActive(false);
       foreach(Transform slot in slots.transform)
       {
           slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
           slot.GetComponent<Slot>().ItemProperty = Slot.property.empty;
       }
       currentSelectedSlot = GameObject.Find("slot_empty");
       previousSelectedSlot = currentSelectedSlot;
   }

   void SelectSlot()
   {
       foreach(Transform slot in slots.transform)
       {
           if(slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty != Slot.property.empty)
           {
               slot.GetComponent<Image>().color = new Color(.9f, .4f, .6f, 1);
           }
           else
           {
               slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
           }
        //    if(slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable) 
        //    {
        //        slot.GetComponent<Slot>().DisplayItem();
        //    }
       }
   }

//    void HideDisplay()
//    {
//        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
//        {
//            itemDisplayer.SetActive(false);
//            if(currentSelectedSlot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
//            {
//                currentSelectedSlot = GameObject.Find("slot_empty");
//                previousSelectedSlot = currentSelectedSlot;
//            }
            
//        }
//    }
}
