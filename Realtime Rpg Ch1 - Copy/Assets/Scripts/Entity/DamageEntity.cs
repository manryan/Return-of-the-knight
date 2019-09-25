using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class DamageEntity : MonoBehaviour
{

    public string targettag;

    public Warrior troop;

    public EffectsPool pool;

    public bool isPlayer;

    public void OnTriggerExit2D(Collider2D c)
    {
        if (c.GetComponent<VIDE_Assign>() != null && isPlayer)
        {
            troop.diagUI.StopCoroutine(troop.diagUI.TextAnimator);
            troop.diagUI.EndDialogue(VD.nodeData);
            troop.diagUI.enabled = false;
            troop.inTrigger = null;
        }
    }

    public void Flip(Transform obj)
    {
        if (transform.position.x > obj.position.x)
        {
            obj.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            obj.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.GetComponent<VIDE_Assign>() != null && isPlayer)
        {

            troop.inTrigger = c.GetComponent<VIDE_Assign>();
            Flip(c.transform);
            troop.diagUI.enabled = true;
            troop.TryInteract();
        }

        if (c.gameObject.tag == targettag)
        {
            Debug.Log("hit " + transform.parent.name);
            var dir = c.gameObject.transform.parent.GetChild(0).up;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            GameObject pfx = pool.GetFx();
            pfx.SetActive(true);
            pfx.transform.position = transform.position;
            pfx.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //Instantiate(pfx, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));

            troop.DamageEntity(troop.damage);
            if(isPlayer && troop.dialogue.activeInHierarchy)
                troop.diagUI.EndDialogue(VD.nodeData);
        }
    }
}
