using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Lid : MonoBehaviour, IInteractable
{
    public int rotate_angle = 30;
    public float time_interval=0.3f;
    public enum State
    {
        close, open, move
    };
    public State state;// {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        state = Lid.State.close;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if(state == Lid.State.close) open();
        if(state == Lid.State.open) close();
    }

    public void open()
    {
        StartCoroutine(waiter_open());
    }

    public void close()
    {
        StartCoroutine(waiter_close());
    }

    IEnumerator waiter_open()
    {
        state = Lid.State.move;
        //Rotate 90 deg
        for(int i=0; i<rotate_angle; i++){
            transform.eulerAngles = new Vector3(0, 0, (float)i);
            yield return new WaitForSeconds(time_interval);
        }
        state = Lid.State.open;
    }

    IEnumerator waiter_close()
    {
        state = Lid.State.move;
        //Rotate 90 deg
        for(int i=rotate_angle; i>0; i--){
            transform.eulerAngles = new Vector3(0, 0, (float)i);
            yield return new WaitForSeconds(time_interval);
        }
        state = Lid.State.close;
    }
}
