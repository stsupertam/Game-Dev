using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    private float score;
    private string playername;

    void Start () {
        score = ScoreController.score;
        playername = PlayerNameController.playername;
        if(PlayerPrefs.GetInt("Player Score") <= score){
            this.transform.Find("Score").GetComponent<Text>().text = "" + score;
            this.transform.Find("Playername").GetComponent<Text>().text = playername;
            PlayerPrefs.SetString("Player Name", playername);
            PlayerPrefs.SetInt("Player Score", (int) score);
        }
        else{
            this.transform.Find("Score").GetComponent<Text>().text = "" + PlayerPrefs.GetInt("Player Score");
            this.transform.Find("Playername").GetComponent<Text>().text = PlayerPrefs.GetString("Player Name");
        }
    }
}
