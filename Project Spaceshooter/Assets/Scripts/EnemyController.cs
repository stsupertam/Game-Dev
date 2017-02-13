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
            other.gameObject.GetComponent<SpaceShipController>().health -= 1;
            if(other.gameObject.GetComponent<SpaceShipController>().health <= 0)
                Destroy(other.gameObject);
        }
    }
}
