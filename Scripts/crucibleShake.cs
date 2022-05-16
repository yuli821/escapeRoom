using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crucibleShake : MonoBehaviour
{
    public bool finishShaking {get; set;}
    public float time_interval = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        finishShaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void shake()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        for(int j=0; j<1; j++)
        {
            for(int i=0; i<10; i++)
            {
                transform.eulerAngles = new Vector3(0, 0, (float)i);
                yield return new WaitForSeconds(time_interval);
            }
            for(int i=10; i>-10; i--)
            {
                transform.eulerAngles = new Vector3(0, 0, (float)i);
                yield return new WaitForSeconds(time_interval);
            }
            for(int i=-10; i<0; i++)
            {
                transform.eulerAngles = new Vector3(0, 0, (float)i);
                yield return new WaitForSeconds(time_interval);
            }
        }
        //bomb_state=2;  // bomb created after shaking
        finishShaking = true;
    }
}

