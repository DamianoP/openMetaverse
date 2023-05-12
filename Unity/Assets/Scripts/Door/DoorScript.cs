using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator door_anim;
    private bool collision;
    private bool can_interact = true;
    private float waitTime = 1f;
    private float next_interaction = -1f;

    void Start()
    {
        collision = false;
    }

    void Update()
    {
        if(Time.time > next_interaction)
        {
            can_interact = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && collision && can_interact)
        {
            door_anim.SetBool("IsClosed", !door_anim.GetBool("IsClosed"));
            next_interaction = Time.time + waitTime;
            can_interact=false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collision = true;
           
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collision = false;         
        }
    }
}
