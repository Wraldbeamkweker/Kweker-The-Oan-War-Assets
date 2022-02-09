using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraP : MonoBehaviour
{
    bool finintro = true;
    bool preintro = true;
    public GameObject[] Script;
    public GameObject Player;
    //public AudioSource menumusique;
    public AudioSource intromusique;
    public Transform inter;
    public Transform player;
    public Transform cabine;
    public Transform titre;
    public Transform skip;
    float OrigineY = 0.5f;
    float OrigineX = 0;
    float OrigineZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        intromusique.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (finintro && preintro && transform.position.y >= 77)
        {
            transform.Translate(0,-0.055f,0);
            cabine.Translate(0,-0.05f,0);
        }
        if (transform.position.y <= 77)
        {
            finintro = false;
            preintro = false;
            titre.transform.position = new Vector3(titre.transform.position.x,titre.transform.position.y,1);
        }
        if (Input.anyKeyDown && transform.position.y >= 57.5f && transform.position.y <= 77)
        {
            skip.position = new Vector3(skip.position.x,skip.position.y,-4);
        }
        if (Input.GetKey(KeyCode.Space) && !finintro && transform.position.y >= 57.5f)
        {
            transform.position = new Vector3(transform.position.x,57.5f,transform.position.z);
            skip.position = new Vector3(skip.position.x,skip.position.y,-10);
            finintro = true;
            preintro = true;
        }
        if (transform.position.y >= 57.5f && !finintro)
        {
            transform.Translate(0,-0.001f,0);
            cabine.Translate(0,-0.00125f,0);
        }
        if (transform.position.y <= 57.5f && !finintro)
        {
            transform.Translate(0,-0.5f,0);
            transform.position = new Vector3(player.position.x,transform.position.y,-5);
            intromusique.Stop();
        }
        if (transform.position.y <= player.position.y+2 && !finintro)
        {
            finintro = true;
            transform.position = new Vector3(player.position.x,player.position.y+2,-5);
            int i = 0;
            while (i != Script.Length)
            {
                Script[i].GetComponent<Adversary>().enabled = true;
                i++;
            }
            Player.GetComponent<Player>().enabled = true;
            inter.position = new Vector3(inter.position.x,inter.position.y,-4);
        }
        if (Input.GetKey(KeyCode.DownArrow) && OrigineY>-0.5f && transform.position.y >= 57.5f)
        {
            transform.Translate(0,-0.02f,0);
            OrigineY -= 0.02f;
        }
        else if (OrigineY < 0.5f && !(Input.GetKey(KeyCode.DownArrow))&& transform.position.y >= 57.5f)
        {
            transform.Translate(0,0.02f,0);
            OrigineY += 0.02f;
        }
        if (Input.GetKey(KeyCode.UpArrow)&&OrigineY<1.5f&& transform.position.y >= 57.5f)
        {
            transform.Translate(0,0.02f,0);
            OrigineY += 0.02f;
        }
        else if (OrigineY > 0.5f && !(Input.GetKey(KeyCode.UpArrow))&& transform.position.y >= 57.5f)
        {
            transform.Translate(0,-0.02f,0);
            OrigineY -= 0.02f;
        }
        if (Input.GetKey(KeyCode.RightArrow)&&OrigineX<1.5f&& transform.position.y >= 57.5f)
        {
            transform.Translate(0.02f,0,0);
            OrigineX += 0.02f;
        }
        else if (OrigineX > 0.5f && !(Input.GetKey(KeyCode.RightArrow))&& transform.position.y >= 57.5f)
        {
            transform.Translate(-0.02f,0,0);
            OrigineX -= 0.02f;
        }
        if (Input.GetKey(KeyCode.LeftArrow)&&OrigineX>-1.5f&& transform.position.y >= 57.5f)
        {
            transform.Translate(-0.02f,0,0);
            OrigineX -= 0.02f;
        }
        else if (OrigineX < 0.5f && !(Input.GetKey(KeyCode.LeftArrow))&& transform.position.y >= 57.5f)
        {
            transform.Translate(0.02f,0,0);
            OrigineX += 0.02f;
        }
        if (Input.GetKey(KeyCode.J)&&OrigineZ < 2&& transform.position.y >= 57.5f)
        {
            transform.Translate(0,0,1);
            OrigineZ += 1f;
        }
        else if (OrigineZ > 0 && !(Input.GetKey(KeyCode.J))&& transform.position.y >= 57.5f)
        {
            transform.Translate(0,0,-1);
            OrigineZ -= 1f;
        }
    }
}
