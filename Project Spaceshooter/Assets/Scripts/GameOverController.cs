using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    private float score;

    void Start () {
        score = ScoreController.score;
        this.transform.Find("Score").GetComponent<Text>().text = "" + score;
    }
}
