using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    private Dictionary<string, float> screen;
    private GameObject plane;
    private bool is_hit = false;
    private ScoreController scorecontrol;

    void Start(){
        plane = GameObject.Find("Plane");
        screen = plane.GetComponent<PlaneController>().get_screen();
        scorecontrol = GameObject.FindObjectOfType<ScoreController>();
    }

    void Update () {
        transform.position += transform.forward * Time.deltaTime * 10f * speed;
        if (this.gameObject.transform.position.z > screen["zMax"] ||
            this.gameObject.transform.position.z < screen["zMin"] ||
            this.gameObject.transform.position.x > screen["xMax"] ||
            this.gameObject.transform.position.x < screen["xMin"]) {
            if(!is_hit)
                scorecontrol.miss += 1;
            Destroy(this.gameObject);
        }
    }
}
