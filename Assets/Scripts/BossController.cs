using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    private Color [] color;
    private GameObject plane;
    public static int boss_health = 20;
    public AudioClip hit, death;
    public ParticleSystem particle;
    public GameObject bullet;
    private Dictionary<string, float> screen;

    void Start(){
        plane = GameObject.Find("Plane");
        screen = plane.GetComponent<PlaneController>().get_screen();
        color = new Color[]{Color.red, Color.yellow, Color.blue, Color.black, Color.cyan, Color.green};
        StartCoroutine(Shoot(2.0f));
    }

    IEnumerator Shoot(float waitTime){
        int angle = 0;
        for(int i=1; i<=8; i++){
            angle += 45;
            Instantiate(bullet,this.gameObject.transform.position,Quaternion.Euler(new Vector3(0, angle, 0)));
        }
        angle = 0; yield return new WaitForSeconds(waitTime);
        StartCoroutine(Shoot(2.0f));
    }

    void OnTriggerEnter(Collider other) {
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", color[Random.RandomRange(0, 5)]);
            boss_health -= 1;
            AudioSource.PlayClipAtPoint(hit, new Vector3(0, 30, 0));
            if(boss_health <= 0){
                Instantiate(particle, other.transform.position,Quaternion.identity);
                ScoreController.score += 1000;
                AudioSource.PlayClipAtPoint(death, new Vector3(0, 30, 0));
                Destroy(this.gameObject);
            }
    }
}

