using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour{

    public float speed;
    public GameObject myBullet;
    public GameObject plane;
    private Dictionary<string, float> screen;
    private float xMin, xMax, zMin, zMax;

    void Start(){
        screen = plane.GetComponent<PlaneController>().get_screen();
    }

    float get_angle(){
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        return angle;
    }
    void rotate(){
        float angle = get_angle();
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 180, 0));
    }

    void movement(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.gameObject.GetComponent<Rigidbody>().velocity = movement * speed * Time.deltaTime * 10f;
        float posx = this.gameObject.GetComponent<Rigidbody>().position.x;
        float posz = this.gameObject.GetComponent<Rigidbody>().position.z;
        this.gameObject.GetComponent<Rigidbody>().position = new Vector3 
            (
             Mathf.Clamp (posx, screen["xMin"], screen["xMax"]), 
             0.0f, 
             Mathf.Clamp (posz, screen["zMin"], screen["zMax"])
             );
    }

    void Update(){
        rotate();
        movement();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Instantiate (myBullet,this.gameObject.transform.position,Quaternion.Euler(new Vector3(0, -get_angle() + 90, 0)));
        }
    }
}
