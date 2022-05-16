using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class ButtonHandler : MonoBehaviour
{
    private DisplayImage currentDisplay;
    
    // private float initialCameraSize;
    // private Vector3 initialCameraPosition;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        // initialCameraSize = Camera.main.orthographicSize;
        // initialCameraPosition = Camera.main.transform.position;
    }

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
        // put the shadow out of the camera
        GameObject.Find("shadow").transform.position = new Vector3(-11, 
            GameObject.Find("shadow").transform.position.y, 
            GameObject.Find("shadow").transform.position.z);
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
        GameObject.Find("shadow").transform.position = new Vector3(9, 
            GameObject.Find("shadow").transform.position.y, 
            GameObject.Find("shadow").transform.position.z);
    }

    public void OnClickReturn()
    {
        // return from painting
        if(currentDisplay.CurrentState == DisplayImage.State.painting)
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentRoom + currentDisplay.CurrentWall);
            currentDisplay.CurrentState = DisplayImage.State.normal;
        }
        // inside the fireplace tunnel, get down to the basement
        if(currentDisplay.CurrentRoom == 2)
        {
            currentDisplay.CurrentState = DisplayImage.State.normal;
        }
        if(currentDisplay.CurrentRoom == 1 || currentDisplay.CurrentRoom == 2)
        {
            currentDisplay.CurrentRoom = currentDisplay.CurrentRoom + 1;
        }
    }
}
