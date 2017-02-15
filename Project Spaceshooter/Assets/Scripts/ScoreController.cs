using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public GameObject spaceship;
    static ScoreController instance = null;
    [HideInInspector]
    public bool gameover = false;
    [HideInInspector]
    public int hit = 0;
    [HideInInspector]
    public int miss = 0;
    [HideInInspector]
    public float score = 0;
    private float accurate = 0;
    private bool endgame = false;

    void Start(){
        if(instance == null) {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Update(){
        if(gameover){
            if(!endgame){
                if(hit + miss != 0)
                    accurate = (hit / (hit + miss *1.0f)) * 100;
                score = score + accurate * 100;
                endgame = true;
            }
        }
    }
}
