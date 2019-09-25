using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Warrior : MonoBehaviour {

    public float regAttTime;

    public float health;

    public int maxHealth;

    public float attCoolDown;

    public bool canAttack;

    public bool attacking;

    public int attackState;

    public Animator anim;

    public float damage;

    public BoxCollider2D damageCol;

    public testmanager diagUI;

    public GameObject dialogue;

    public bool quest1;

    //Stored current VA when inside a trigger
    public VIDE_Assign inTrigger;


    public void TryInteract()
    {
        /* Prioritize triggers */

        if (inTrigger)
        {
            diagUI.Interact(inTrigger);
            return;
        }
    }


    public virtual IEnumerator WeaponCoolDown()
    {
        yield return new WaitUntil(() => anim.GetBool("attacking") == false);
        yield return new WaitForSeconds(regAttTime);
        canAttack = true;
        attackState = 0;
        attacking = false;
        // attackState = 0;
        // anim.SetFloat("attackState", attackState);
    }

    public virtual void DamageEntity(float Damage)
    {
        health -= Damage;
      //  if (health <= 0)
       //     Debug.Log("died");
    }
}
