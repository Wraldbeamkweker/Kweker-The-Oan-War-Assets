using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    public float movement;
    public float Lifetime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (movement != 0 && !collision.transform.CompareTag("AttackPlayer"))
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,Lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (movement != 0)
        {
            transform.Translate(movement,0,0);
        }
    }
}
