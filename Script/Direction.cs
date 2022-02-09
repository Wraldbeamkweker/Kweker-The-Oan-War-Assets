using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    bool DirectionLeft = false;
    bool crouch = false;
    public bool rotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.position = new Vector3(-7.5f,transform.position.y,0);
            if (!DirectionLeft){
                if(crouch && rotate){
                    transform.Rotate (0,0,-90,Space.World);
                } else {
                    transform.Rotate (0,0,180,Space.World);
                }
                DirectionLeft = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            transform.position = new Vector3(7.5f,transform.position.y,0);
            if (DirectionLeft){
                if(crouch && rotate){
                    transform.Rotate (0,0,90,Space.World);
                } else {
                    transform.Rotate (0,0,180,Space.World);
                }
                DirectionLeft = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            transform.position = new Vector3(transform.position.x,-3.5f,0);
            if (!crouch && rotate){
                if (DirectionLeft){
                    transform.Rotate (0,0,45,Space.World);
                } else {
                    transform.Rotate (0,0,-45,Space.World);
                }
                crouch = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            transform.position = new Vector3(transform.position.x,3.5f,0);
            if (crouch && rotate){
                if (DirectionLeft){
                    transform.Rotate (0,0,-45,Space.World);
                } else {
                    transform.Rotate (0,0,45,Space.World);
                }
                crouch = false;
            }
        }
    }
}
