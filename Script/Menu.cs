using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    int choix = 1;
    bool zoom = false;
    float zoomlevel = 14;
    public GameObject lancement;
    public AudioSource menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(choix == 1)
        {
            transform.position = new Vector3(transform.position.x,110.6f,transform.position.z);
        }
        if(choix == 2)
        {
            transform.position = new Vector3(transform.position.x,107.7f,transform.position.z);
        }
        if(choix == 3)
        {
            transform.position = new Vector3(transform.position.x,104.6f,transform.position.z);
        }
        if(choix == 4)
        {
            transform.position = new Vector3(transform.position.x,101.6f,transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)&& choix < 4)
        {
            choix++;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)&& choix > 1)
        {
            choix--;
        }
        if(Input.GetKeyDown(KeyCode.Space)&& choix == 1){
            lancement.GetComponent<CameraP>().enabled = true;
            zoom = true;
            menu.Stop();
        }
        if(zoom && zoomlevel >= 5.5f){
            zoomlevel -= 0.1f;
            lancement.GetComponent<Camera>().orthographicSize = zoomlevel;
        }
        if(zoom && zoomlevel < 5.5f){
            GetComponent<Menu>().enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.Space)&& choix == 4){
        }
    }
}
