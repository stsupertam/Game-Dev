using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject Spaceship;
    private Text score_text;
    private int health;

    public void display_heart(string heart){
        Transform heart_display = this.transform.Find(heart);
        if(heart_display)
            this.transform.Find(heart).GetComponent<RawImage>().enabled = false;
    }

    void Start(){
        score_text = this.transform.Find("score").GetComponent<Text>();
    }

    void Update(){
        score_text.text = "" + Mathf.RoundToInt(ScoreController.score);
    }
}
