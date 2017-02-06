using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject LightObject;
    public bool LightStatus;
    // Use this for initialization
    void Start()
    {
		
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
    }
    void OnGUI()
    {

        if (LightStatus == true)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), "Turn OFF"))
            {
                Debug.Log(Time.time + "Hello World");
                LightStatus = false;
                LightObject.GetComponent<Light>().enabled = false;
            }
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), "Turn ON"))
            {
                Debug.Log(Time.time + "Hello World");
                LightStatus = true;
                LightObject.GetComponent<Light>().enabled = true;
            }
        }
    }
}
