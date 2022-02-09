using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float start;
    public float end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.01f,0,0);
        if (transform.position.x <= end)
        {
            transform.position = new Vector3(start,transform.position.y,transform.position.z);
        }
    }
}
