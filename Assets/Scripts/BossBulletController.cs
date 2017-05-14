using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour {

    public float speed;
    private Dictionary<string, float> screen;
    private GameObject plane;
    private Canvas ui;

    void Start(){
        plane = GameObject.Find("Plane");
        screen = plane.GetComponent<PlaneController>().get_screen();
        ui = GameObject.FindObjectOfType<Canvas>();
    }

    void Update () {
        transform.position += transform.forward * Time.deltaTime * 10f * speed;
        if (this.gameObject.transform.position.z > screen["zMax"] ||
            this.gameObject.transform.position.z < screen["zMin"] ||
            this.gameObject.transform.position.x > screen["xMax"] ||
            this.gameObject.transform.position.x < screen["xMin"]) {
            Destroy(this.gameObject);
        }
    }

    void spaceship_handle(GameObject spaceship){
        int health = spaceship.GetComponent<SpaceShipController>().health;
        string heart = "heart_" + health;
        ui.GetComponent<UIController>().display_heart(heart);
        spaceship.GetComponent<SpaceShipController>().health -= 1;
        Debug.Log(health);
        if(spaceship.GetComponent<SpaceShipController>().health <= 0){
            ScoreController.gameover = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Spaceship"){
            GameObject spaceship = other.gameObject;
            spaceship_handle(spaceship);
        }
        Destroy(this.gameObject);
    }

}
