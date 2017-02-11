using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {
    private float height;
    private float width;

    // Use this for initialization
    void Start () {
        float distance = Camera.main.transform.position.y - this.transform.position.y;
        height = 2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * distance;
        width = height * Screen.width / Screen.height;		
    }
	
    // Update is called once per frame
    void Update () {
        this.transform.localScale = new Vector3(height, 1.0f, width);

    }
}
