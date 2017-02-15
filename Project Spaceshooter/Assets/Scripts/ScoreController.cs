using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    static ScoreController instance = null;
    public static bool gameover = false;
    public static float score = 0;

    void Awake(){
        gameover = false;
        score = 0;

    }
}
