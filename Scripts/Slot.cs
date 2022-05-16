using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject inventory;
    // declare a enum type the property of the item in the slot
    public enum property {usable, displayable, empty}; 
    public property ItemProperty {get; set;} // declare a variable of the type
    //private string displayImage;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // do nothing if click on a empty slot
        if(this.gameObject.GetComponent<Slot>().ItemProperty != Slot.property.empty)
        {
            inventory.GetComponent<Inventory>().previousSelectedSlot = inventory.GetComponent<Inventory>().currentSelectedSlot;
            inventory.GetComponent<Inventory>().currentSelectedSlot = this.gameObject;
            //Combine();
        }
        
    }

    public void AssignProperty(int orderNumber)     //string displayImage, string combinationItem
    {
        ItemProperty = (property)orderNumber;
        //this.displayImage = displayImage;
        //CombinationItem = combinationItem;
    }

    // public void DisplayItem()
    // {
    //     inventory.GetComponent<Inventory>().itemDisplayer.SetActive(true);
    //     inventory.GetComponent<Inventory>().itemDisplayer.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/" + displayImage);
    // }

    public void ClearSlot()
    {
        ItemProperty = Slot.property.empty;
        //displayImage = "";
        //CombinationItem = "";
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
