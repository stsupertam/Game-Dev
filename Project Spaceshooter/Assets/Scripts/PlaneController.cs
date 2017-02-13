using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {
    private float height;
    private float width;
    public Dictionary<string, float> screen;

    public Dictionary<string, float> get_screen(){
        screen = new Dictionary<string, float>();
        screen.Add("xMin", -width/2.0f);
        screen.Add("xMax", width/2.0f);
        screen.Add("zMin", -height/2.0f);
        screen.Add("zMax", height/2.0f);
        return screen;
    }

    void Start () {
        float distance = Camera.main.transform.position.y - this.transform.position.y;
        height = 2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * distance;
        width = height * Screen.width / Screen.height;
        this.transform.localScale = new Vector3(height, 1.0f, width);
    }
}
