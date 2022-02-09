using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret: MonoBehaviour
{
    public GameObject back;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            transform.position = new Vector3(0,0,-6);
            if (back)
            {
                back.transform.position = new Vector3(0,0,-4);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            transform.position = new Vector3(0,0,-4);
            if (back)
            {
                back.transform.position = new Vector3(0,0,-6);
            }
        }
        if (GetComponent<Collider2D>().enabled == false)
        {
            transform.position = new Vector3(0,0,-6);
            back.transform.position = new Vector3(0,0,-4);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
