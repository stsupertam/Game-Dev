using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public AudioClip myExplosion;
    public float speed;

    void Update () {
        this.gameObject.transform.Translate (Vector3.forward * Time.deltaTime * 10f);
        transform.position += transform.forward * Time.deltaTime * 10f * speed;
        if (this.gameObject.transform.position.z >= 20f) {
            Destroy (this.gameObject);
        }
    }


    void OnTriggerEnter(Collider other){
        Destroy(other.gameObject);
        this.gameObject.GetComponent<AudioSource>().clip = myExplosion;
        this.gameObject.GetComponent<AudioSource>().Play ();
    }
}
