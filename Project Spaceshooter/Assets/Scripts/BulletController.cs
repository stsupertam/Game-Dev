using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public AudioClip explosion;
    private Dictionary<string, float> screen;
    private GameObject plane;

    void Start(){
        plane = GameObject.Find("Plane");
        screen = plane.GetComponent<PlaneController>().get_screen();
    }

    void Update () {
        transform.position += transform.forward * Time.deltaTime * 10f * speed;
        Debug.Log(screen["zMax"]);
        if (this.gameObject.transform.position.z > screen["zMax"] ||
            this.gameObject.transform.position.z < screen["zMin"] ||
            this.gameObject.transform.position.x > screen["xMax"] ||
            this.gameObject.transform.position.x < screen["xMin"]) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
        AudioSource.PlayClipAtPoint(explosion, new Vector3(0, 30, 0));
        Destroy(other.gameObject);
    }
}
