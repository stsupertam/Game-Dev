using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public GameObject spaceship;
    [HideInInspector]
    public int bullet_create = 0;
    [HideInInspector]
    public int enemy_destroy = 0;
    [HideInInspector]
    public double score = 0;
    private double accurate = 0;
    private bool endgame = false;

    void Start(){
    }

    void Update() {
        Debug.Log("Score : " + score);
        Debug.Log("Enemy_destroy : " + enemy_destroy);
        Debug.Log("Bullet_create : " + bullet_create);
        if(spaceship.GetComponent<SpaceShipController>().gameover){
            if(!endgame){
                accurate = (enemy_destroy / (bullet_create * 1.0)) * 100;
                Debug.Log("Accurate : " + accurate);
                score = score + accurate * 100;
                Debug.Log("Score : " + score);
                endgame = true;
            }
        }
    }
}
