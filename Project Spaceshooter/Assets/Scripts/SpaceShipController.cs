using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour{

    // Use this for initialization
    public float speed;
    public GameObject myBullet;
    public GameObject plane;
    private float [] screen;
    private float xMin, xMax, zMin, zMax;
    void Start(){
        screen = plane.GetComponent<PlaneController>().get_screen();
        xMin = -screen[1]/2.0f;
        xMax = screen[1]/2.0f;
        zMin = -screen[0]/2.0f;
        zMax = screen[0]/2.0f;
    }

    void movement(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.gameObject.GetComponent<Rigidbody>().velocity = movement * speed * Time.deltaTime * 10f;
        float posx = this.gameObject.GetComponent<Rigidbody>().position.x;
        float posz = this.gameObject.GetComponent<Rigidbody>().position.z;
        this.gameObject.GetComponent<Rigidbody>().position = new Vector3 
            (
             Mathf.Clamp (posx, xMin, xMax), 
             0.0f, 
             Mathf.Clamp (posz, zMin, zMax)
             );
    }

    void Update(){
        movement();
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate (myBullet,this.gameObject.transform.position,Quaternion.identity);
        }
    }
}
