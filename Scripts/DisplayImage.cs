using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class manage which picture is showing on the screen. 
// i.e.: we are looking at which wall, which object
public class DisplayImage : MonoBehaviour
{

    public enum State
    {
        normal, painting, roomTransition
    };

    // Other class can access the class member CurrentState.
    public State CurrentState { get; set; } 

    public GameObject black_scene;

    // Other class can access the class member CurrentState, is also a interface with button
    public int CurrentWall
    {
        get { return currentWall; }
        set 
        {
            if (value == 4)
                currentWall = 0;
            else if (value == -1)
                currentWall = 3;
            else 
                currentWall = value;
        }
    }

    private int currentWall;
    private int previousWall;

    public int CurrentRoom { get; set; }    // 0: first room; 1, 2: inside fireplace; 3: basement
    private int previousRoom;

    void Start()
    {
        previousWall = -1;
        currentWall = 1;
        CurrentState = State.normal;
        previousRoom = -1;
        CurrentRoom = 3;
    }

    void Update()
    {
        // change wall when pressing button
        if(currentWall != previousWall)
        {
            GameObject.Find("shadow").GetComponent<ShadowAnimation>().state = ShadowAnimation.State.to_idle;
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + CurrentRoom.ToString() + currentWall.ToString());
        }
        previousWall = currentWall;
        if(CurrentRoom != previousRoom) // maybe can be simpler... whatever
        {
            //GameObject.Find("shadow").GetComponent<ShadowAnimation>().state = ShadowAnimation.State.to_idle;
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + CurrentRoom.ToString() + currentWall.ToString());
        }
        previousRoom = CurrentRoom;
        if(CurrentRoom == 1 || CurrentRoom == 2){
            CurrentState = State.roomTransition;
        }
    }
}

            // black_scene.SetActive(true);
            // StartCoroutine(waiter());
            // black_scene.SetActive(false);
        // else
        // {
        //     black_scene.SetActive(false);
        // }

    // IEnumerator waiter()
    // {
    //     //Rotate 90 deg
    //     for(int i=0; i<50; i++){
    //         black_scene.SetActive(true);
    //         yield return new WaitForSeconds(0.1f);
    //     }
    //     Debug.Log("black!");
    // }