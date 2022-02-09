using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soin : MonoBehaviour
{
    public int volume;
    public bool tempo;
    public Player play;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            play.healDamage(volume);
            if (tempo){
                Destroy(gameObject);
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
        
    }
}
