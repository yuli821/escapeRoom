using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Crucible : MonoBehaviour, IInteractable
{
    public float speed = 5f;  
    public float time_interval=1f;
    public string[] UnlockItem;
    public bool[] unlocked;
    public GameObject[] dropItem;
    public GameObject bomb;
    private GameObject inventory;
    private crucibleShake crucible;
    private Lid.State lidState;
    public bool[] dropping;
    public int bomb_state;
    private float posX = 1.45f;
    private float posY = 0.26f;
    private float distance = 2.5f;
    
    void Start()
    {
        inventory = GameObject.Find("Inventory");
        crucible = GameObject.Find("crucible").GetComponent<crucibleShake>();
        bomb_state = 0;     // not created
    }

    void Update()
    {
        lidState = GameObject.Find("crucible_lid").GetComponent<Lid>().state;
        if(unlocked[0] && unlocked[1] && unlocked[2] && lidState==Lid.State.close && bomb_state==0) 
        {
            bomb_state=1;
            crucible.shake();     // bomb creating
        }
        for(int i=0; i<3; i++) if(dropping[i]) drop(i);
        if(crucible.finishShaking && bomb_state==1) bomb_arise(); // bomb created after shaking
    }
    
    public void Interact(DisplayImage currentDisplay)
    {
        if(lidState==Lid.State.open)
        {
            for(int i=0; i<3; i++)
            {
                if(inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem[i])
                {
                    inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ClearSlot();
                    dropItem[i].SetActive(true);
                    dropping[i] = true;
                }
            }   
        }
    }

    private void drop(int i)
    {
        Vector3 targetPosition = new Vector3(posX, posY-distance, 0);
        dropItem[i].transform.position = Vector3.MoveTowards(dropItem[i].transform.position, targetPosition, speed * Time.deltaTime);
        // stop moving when reach the spot
        if (targetPosition == dropItem[i].transform.position) {
            dropItem[i].SetActive(false);
            dropping[i]=false;
            unlocked[i]=true;
        }
    }

    private void bomb_arise()
    {
        bomb.SetActive(true);
        Vector3 targetPosition = new Vector3(1.45f, 1f, 0f);
        if(lidState==Lid.State.open) bomb.transform.position = Vector3.MoveTowards(bomb.transform.position, targetPosition, speed * Time.deltaTime);
        // stop moving when reach the spot
        if (targetPosition == bomb.transform.position) bomb_state = 3;      // already arised
    }
}