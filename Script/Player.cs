using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int sante;
    bool vuln = true;
    int invincTime = 0;
    public int gameOver = 0;
    Vector3 Origine;
    public AudioSource ambiance;
    public AudioSource fingame;
    public GameObject traversable;
    public GameObject Gameover;
    public GameObject Gameover2;
    public GameObject Gameover3;
    public GameObject Gameover4;
    public GameObject Gameover5;
    public GameObject Cam;
    Color fondu;
    Color Mosaica;
    Transform ActualCheck;
    public GameObject Punch;
    public GameObject Tir;
    public Rigidbody2D rb;
    public Animator ame;
    public GameObject energy;
    public GameObject expression;
    bool saut = false;
    bool boost = false;
    private Vector3 vel = Vector3.zero;
    public float movespeed;
    public void takeDamage(int dmg)
    {
        if (sante != 0)
        {
            if (vuln == true)
            {
                sante -= dmg;
                vuln = false;
            }
        }
    }
    public void healDamage(int soin)
    {
        if (sante != 0)
        {
            if (sante < 16)
            {
                sante += soin;
                if (sante > 16){
                    sante = 16;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Respawn"))
        {
            if (!(ActualCheck is null))
            {
                ActualCheck.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            Origine = transform.position;
            ActualCheck = collision.transform;
            ActualCheck.GetComponent<SpriteRenderer>().color = Color.green;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Level")&& (saut))
        {
            saut = false;
            boost = false;
        }
        if (collision.transform.CompareTag("Ennemy"))
        {
            Vector3 repouss = (collision.transform.position - transform.position)*-1;
            transform.Translate(repouss.normalized,Space.World);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Origine = transform.position;
        ambiance.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,0);
        if (transform.position.y <= 16)
        {
            transform.position = Origine;
            takeDamage(2);
            vuln = false;
        }
        if (sante > 0)
        {
            if (vuln == false)
            {
                if (GetComponent<SpriteRenderer>().color == Color.white)
                {
                GetComponent<SpriteRenderer>().color = Color.red;
                energy.GetComponent<SpriteRenderer>().color = Color.red;
                expression.GetComponent<SpriteRenderer>().color = Color.red;
                } 
                else 
                {
                GetComponent<SpriteRenderer>().color = Color.white;
                energy.GetComponent<SpriteRenderer>().color = Color.white;
                expression.GetComponent<SpriteRenderer>().color = Color.white;
                }
                if (invincTime >= 100)
                {
                    vuln = true;
                    invincTime = 0;
                }
                invincTime++;
            } 
            else 
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                energy.GetComponent<SpriteRenderer>().color = Color.white;
                expression.GetComponent<SpriteRenderer>().color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                GameObject attaque;
                attaque = Instantiate(Punch, GetComponent<Transform>());
                attaque.GetComponent<Direction>().enabled = false;
                attaque.GetComponent<Temporary>().enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                GameObject attaquetir;
                attaquetir = Instantiate(Tir, GetComponent<Transform>());
                attaquetir.GetComponent<Direction>().enabled = false;
                attaquetir.GetComponent<Temporary>().enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.Space)&&!(saut))
            {
                rb.AddForce(new Vector2(0,300f));
                saut = true;
            }
            if(!Input.GetKey(KeyCode.DownArrow))
            {
                traversable.GetComponent<Collider2D>().enabled = true;
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                traversable.GetComponent<Collider2D>().enabled = false;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                traversable.GetComponent<Collider2D>().enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.C)&&!(boost))
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    rb.AddForce(new Vector2(0,-500f));
                } 
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.AddForce(new Vector2(-3000f,0));
                } 
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    rb.AddForce(new Vector2(3000f,0));
                } 
                else 
                {
                    rb.AddForce(new Vector2(0,300f));
                }
                boost = true;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.position = Origine;
            }
            float Xmov = Input.GetAxis("Horizontal") * movespeed;
            Vector3 mouv = new Vector2(Xmov, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, mouv, ref vel, 0.05f);
            ame.SetFloat("Move", Xmov);
        }
        ame.SetInteger("Sante", sante);
        energy.GetComponent<Animator>().SetInteger("Sante", sante);
        expression.GetComponent<Animator>().SetInteger("Sante", sante);
        if (sante == 0)
        {
            ambiance.Stop();
            if (gameOver == 200)
            {
                fingame.Play();
                fondu = Color.blue;
                Mosaica = Color.white;
                fondu.a = 0;
                Mosaica.a = 0;
                Gameover.transform.position = new Vector3(Gameover.transform.position.x,Gameover.transform.position.y,-4);
                Gameover2.GetComponent<SpriteRenderer>().color = Mosaica;
                Gameover3.GetComponent<SpriteRenderer>().color = Mosaica;
                Gameover4.GetComponent<SpriteRenderer>().color = Mosaica;
                Gameover5.GetComponent<SpriteRenderer>().color = Mosaica;
                gameOver++;
            } 
            else if (gameOver <= 250)
            {
                fondu.a += 0.1f;
                Mosaica.a += 0.1f;
                Gameover.GetComponent<SpriteRenderer>().color = fondu;
                gameOver++;
            } 
            else if (gameOver <= 300)
            {
                fondu.b -= 0.025f;
                Gameover.GetComponent<SpriteRenderer>().color = fondu;
                Gameover2.GetComponent<SpriteRenderer>().color = fondu;
                Gameover3.GetComponent<SpriteRenderer>().color = fondu;
                Gameover4.GetComponent<SpriteRenderer>().color = Mosaica;
                Gameover5.GetComponent<SpriteRenderer>().color = Mosaica;
                gameOver++;
            } 
            else if (gameOver >= 350)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Gameover.transform.position = new Vector3(Gameover.transform.position.x,Gameover.transform.position.y,-6);
                    sante = 16;
                    transform.position = Origine;
                    gameOver = 0;
                    fingame.Stop();
                    ambiance.Play();
                }
            }
            else 
            {
                Gameover.GetComponent<SpriteRenderer>().color = fondu;
                Gameover2.GetComponent<SpriteRenderer>().color = fondu;
                Gameover3.GetComponent<SpriteRenderer>().color = fondu;
                gameOver++;
            }
        }
    }
}
