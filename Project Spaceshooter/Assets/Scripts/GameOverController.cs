using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    private float score;
    private string username;

    void Start () {
        score = ScoreController.score;
        this.transform.Find("Score").GetComponent<Text>().text = "" + score;
        this.transform.Find("Username").GetComponent<Text>().text = UserNameController.username;
    }
}
