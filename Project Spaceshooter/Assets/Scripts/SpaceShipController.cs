using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour{

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

    void rotate(){
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 180, 0));
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
        rotate();
        movement();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Instantiate (myBullet,this.gameObject.transform.position,Quaternion.identity);
        }
    }
}
