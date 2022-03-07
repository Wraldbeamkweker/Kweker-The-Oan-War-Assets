using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionWait : MonoBehaviour
{
    int timer = 0;
    int InOut = 0;
    Color fondu;
    Color iconCol;
    public GameObject icon;
    public void waitScreen(int time){
        fondu = GetComponent<SpriteRenderer>().color;
        iconCol = icon.GetComponent<SpriteRenderer>().color;
        while (InOut <= 100){
            fondu.a += 0.25f;
            iconCol.a += 0.25f;
            InOut++;
            GetComponent<SpriteRenderer>().color = fondu;
            icon.GetComponent<SpriteRenderer>().color = iconCol;
        }
        while (timer <= time){
            timer++;
        }
        while (InOut >= 0){
            fondu.a -= 0.25f;
            iconCol. a-= 0.25f;
            InOut--;
            GetComponent<SpriteRenderer>().color = fondu;
            icon.GetComponent<SpriteRenderer>().color = iconCol;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        fondu = GetComponent<SpriteRenderer>().color;
        iconCol = icon.GetComponent<SpriteRenderer>().color;
        while (InOut <= 100){
            fondu.a += 0.25f;
            iconCol.a += 0.25f;
            InOut++;
            GetComponent<SpriteRenderer>().color = fondu;
            icon.GetComponent<SpriteRenderer>().color = iconCol;
        }
        while (timer <= 100){
            timer++;
        }
        while (InOut >= 0){
            fondu.a -= 0.25f;
            iconCol. a-= 0.25f;
            InOut--;
            GetComponent<SpriteRenderer>().color = fondu;
            icon.GetComponent<SpriteRenderer>().color = iconCol;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            waitScreen(100);
        }
    }
}
