using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour {

    public GameObject Spaceship;
    private int health;

    public void display_heart(string heart){
        this.gameObject.transform.Find(heart).GetComponent<RawImage>().enabled = false;
    }

    void Start(){
        // this.gameObject.transform.position
    }
}
