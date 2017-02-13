using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour{

    public int health;
    public float speed;
    public GameObject myBullet;
    public GameObject plane;
    public LevelManager levelManager;
    public bool gameover;
    private float timer;
    private Dictionary<string, float> screen;
    private float xMin, xMax, zMin, zMax;

    void Start(){
        gameover = false;
        screen = plane.GetComponent<PlaneController>().get_screen();
        timer = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
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
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 180, 0));
    }

    void movement(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.gameObject.GetComponent<Rigidbody>().velocity = movement * speed * Time.deltaTime * 10f;
        float posx = this.gameObject.GetComponent<Rigidbody>().position.x;
        float posz = this.gameObject.GetComponent<Rigidbody>().position.z;
        this.GetComponent<Rigidbody>().position = new Vector3 
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
        if(gameover){
            this.gameObject.GetComponent<Renderer>().enabled = false;
            timer += Time.deltaTime;
            Debug.Log(timer);
            if(timer >= 1f){
                levelManager.LoadLevel("Game_Over_Screen");
            }
        }
    }
}
