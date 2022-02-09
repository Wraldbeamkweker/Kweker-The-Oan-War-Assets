using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rentrer : MonoBehaviour
{
    public GameObject play;
    public GameObject cam;
    public GameObject porte;
    public GameObject camouflage;
    public AudioSource ground;
    public AudioSource waiting;
    public AudioSource vaisseau;
    bool musique = true;
    bool retour = false;
    bool entrer = true;
    public void retourvaisseau(){
        if (Input.GetKeyDown(KeyCode.F)){
            transform.position = new Vector3(-43,70,transform.position.z);
            play.transform.position = new Vector3(-59,95,play.transform.position.z);
        }
    }
    public void sortievaisseau(){
        if (Input.GetKeyDown(KeyCode.F)){
            transform.position = new Vector3(0,10,transform.position.z);
            play.transform.position = new Vector3(-16.65f,35.15f,play.transform.position.z);
        }
    }
    private void OnCollisionStay2D(Collision2D collision){
        if (collision.transform.CompareTag("Player")){
            if (Input.GetKeyDown(KeyCode.V)){
                if (retour == false){
                    ground.Stop();
                    waiting.Play();
                    musique = false;
                    retour = true;
                    entrer = false;
                    camouflage.GetComponent<Collider2D>().enabled = false;
                } else if (entrer == false){
                    vaisseau.Stop();
                    waiting.Play();
                    musique = false;
                    retour = false;
                    entrer = true;
                    camouflage.GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (retour == true){
            porte.GetComponent<Collider2D>().enabled = false;
            if (cam.transform.position.y >=51.2f && transform.position.x != -43){
                transform.position = new Vector3(-43,transform.position.y,transform.position.z);
                play.transform.position = new Vector3(-59,play.transform.position.y+0.5f,play.transform.position.z);
                retourvaisseau();
            }
            if (transform.position.y < 80){
                porte.GetComponent<Collider2D>().enabled = true;
                transform.position = new Vector3(transform.position.x,transform.position.y+0.02f,transform.position.z);
                retourvaisseau();
            }
            if (transform.position.y >= 80){
                waiting.Stop();
                camouflage.GetComponent<Collider2D>().enabled = true;
                if (musique == false)
                {
                    vaisseau.Play();
                    musique = true;
                }
            }
        }
        if (entrer == true){
            porte.GetComponent<Collider2D>().enabled = false;
            if (cam.transform.position.y <=51.2f && transform.position.x != 0){
                transform.position = new Vector3(0,transform.position.y,transform.position.z);
                play.transform.position = new Vector3(-16.65f,play.transform.position.y-0.5f,play.transform.position.z);
                sortievaisseau();
            }
            if (transform.position.y > 0){
                porte.GetComponent<Collider2D>().enabled = true;
                transform.position = new Vector3(transform.position.x,transform.position.y-0.02f,transform.position.z);
                sortievaisseau();
            }
            if (transform.position.y <= 0){
                camouflage.GetComponent<Collider2D>().enabled = true;
                waiting.Stop();
                if (musique == false)
                {
                    musique = true;
                    ground.Play();
                }
            }
        }
    }
}
