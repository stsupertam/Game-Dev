using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public AudioClip spaceship_explosion;
    public AudioClip enemy_explosion;
    private GameObject plane;
    private Dictionary<string, float> screen;

    void Start(){
        speed = Random.Range(0f, 10f);
        plane = GameObject.Find("Plane");
        screen = plane.GetComponent<PlaneController>().get_screen();
    }

    void Update(){
        this.transform.position -= transform.forward * Time.deltaTime * 10f * speed;
        if (this.gameObject.transform.position.z > screen["zMax"] ||
            this.gameObject.transform.position.z < screen["zMin"] ||
            this.gameObject.transform.position.x > screen["xMax"] ||
            this.gameObject.transform.position.x < screen["xMin"]) {
            Destroy (this.gameObject);
        }
    }

    void spaceship_handle(GameObject spaceship){
        int health = spaceship.GetComponent<SpaceShipController>().health;
        string heart = "heart_" + health;
        spaceship.transform.Find("Canvas").gameObject.GetComponent<HeartController>().display_heart(heart);
        spaceship.GetComponent<SpaceShipController>().health -= 1;
        AudioSource.PlayClipAtPoint(enemy_explosion, new Vector3(0, 30, 0));
        if(spaceship.GetComponent<SpaceShipController>().health <= 0){
            AudioSource.PlayClipAtPoint(spaceship_explosion, new Vector3(0, 30, 0));
            spaceship.GetComponent<SpaceShipController>().gameover = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        if(other.gameObject.name == "Spaceship"){
            GameObject spaceship = other.gameObject;
            spaceship_handle(spaceship);
        }
    }
}

