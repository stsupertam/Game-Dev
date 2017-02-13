using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;

    void Start(){
        speed = Random.Range(0f, 10f);
    }

    void Update() {
        this.transform.position -= transform.forward * Time.deltaTime * 10f * speed;
    }

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        if(other.gameObject.name == "Spaceship"){
            GameObject spaceship = other.gameObject;
            int health = spaceship.GetComponent<SpaceShipController>().health;
            string heart = "heart_" + health;
            spaceship.transform.Find("Canvas").gameObject.GetComponent<HeartController>().display_heart(heart);
            spaceship.GetComponent<SpaceShipController>().health -= 1;
            if(spaceship.GetComponent<SpaceShipController>().health <= 0)
                Destroy(other.gameObject);
        }
    }
}
