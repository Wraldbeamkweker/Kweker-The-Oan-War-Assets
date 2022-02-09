using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationtilemap2 : MonoBehaviour
{
    public GameObject P2;
    public GameObject PA;
    public GameObject PA2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z == 4)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,5);
            PA.transform.position = new Vector3(PA.transform.position.x,PA.transform.position.y,4);
            if (P2 && PA2)
            {
                P2.transform.position = new Vector3(P2.transform.position.x,P2.transform.position.y,6);
                PA2.transform.position = new Vector3(PA2.transform.position.x,PA2.transform.position.y,5);
            }
        } 
        else
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,4);
            PA.transform.position = new Vector3(PA.transform.position.x,PA.transform.position.y,5);
            if (P2 && PA2)
            {
                P2.transform.position = new Vector3(P2.transform.position.x,P2.transform.position.y,5);
                PA2.transform.position = new Vector3(PA2.transform.position.x,PA2.transform.position.y,6);
            }
        }
    }
}
