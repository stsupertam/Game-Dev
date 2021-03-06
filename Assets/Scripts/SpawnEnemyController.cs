﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyController : MonoBehaviour {

    public GameObject myEnemy, plane;
    private Dictionary<string, float> screen;
    private float posx, posz, rand;
    private string [] spawn_name;
    private float spawn_angle;

    void get_spawn_attribute(){
        spawn_name = this.gameObject.name.Split('_');
        if(spawn_name[1] == "X"){
            posx = this.transform.position.x * screen["xMax"];
            rand = screen["xMax"];
        }
        else{
            posz = this.transform.position.z * screen["zMax"];
            rand = screen["zMax"];
        }
    }

    void Start() {
        screen = plane.GetComponent<PlaneController>().get_screen();
        get_spawn_attribute();
        StartCoroutine(SpawnEnemy(1.0f));
    }

    IEnumerator SpawnEnemy(float waitTime){
        float random_pos = Random.Range(-rand, rand);
        if(spawn_name[1] == "X")
            this.transform.position = new Vector3(posx, 0.5f, random_pos);
        else
            this.transform.position = new Vector3(random_pos, 0.5f, posz);
        Instantiate (myEnemy, this.gameObject.transform.position, Quaternion.Euler(0,transform.eulerAngles.y ,0));
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(SpawnEnemy (1.0f));
    }
}
