using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossController : MonoBehaviour {

    public GameObject Boss, plane;
    private bool is_Coroutine = false;
    private Dictionary<string, float> screen;
    private float randx, randz;

    void get_spawn_attribute(){
        randx = screen["xMax"];
        randz = screen["zMax"];
    }

    void Start(){
        screen = plane.GetComponent<PlaneController>().get_screen();
        get_spawn_attribute();
    }

    void Update() {
        if(!is_Coroutine){
            is_Coroutine = true;
            StartCoroutine(SpawnBoss(7.0f));
        }
    }

    IEnumerator SpawnBoss(float waitTime){
        yield return new WaitForSeconds(waitTime);
        float random_posx = Random.Range(-randx, randx);
        float random_posz = Random.Range(-randz, randz);
        this.transform.position = new Vector3(random_posx, 0.5f, random_posz);
        Instantiate (Boss, this.gameObject.transform.position, Quaternion.identity);
        BossController.boss_health = 20;
        is_Coroutine = false;
    }
}
