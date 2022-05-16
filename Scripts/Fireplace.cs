using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Fireplace : MonoBehaviour, IInteractable
{

    
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
        // go inside the fireplace
        currentDisplay.CurrentRoom = currentDisplay.CurrentRoom + 1;
    }

}
