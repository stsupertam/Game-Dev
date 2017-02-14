using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour {

    public GameObject Spaceship;
    private int health;

    public void display_heart(string heart){
        Transform heart_display = this.gameObject.transform.Find(heart);
        if(heart_display)
            this.gameObject.transform.Find(heart).GetComponent<RawImage>().enabled = false;
    }
}
