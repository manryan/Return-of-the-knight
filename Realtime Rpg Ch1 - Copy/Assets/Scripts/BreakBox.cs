using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBox : MonoBehaviour
{

    public Animator anim;

    public BoxCollider2D box;

    public BoxCollider2D trigger;

    

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag=="Psword")
        {
            box.enabled = false;
            trigger.enabled = false;
            anim.Play("breakbox");
        }
    }
}