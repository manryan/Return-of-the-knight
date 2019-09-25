using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    public SpriteRenderer sprite;

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            sprite.color = new Color(1, 1, 1, 0.3f);
        }
    }

    public void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
    }

    //  public Bark bark;

    /* public void OnTriggerExit2D(Collider2D c)
     {
         if (c.gameObject.tag == "Player")
         {
             bool checker = false;
             int index = 0;
             for (int i = 0; i < bark.myData.Count; i++)
             {
                 if (bark.myData[i].obj == c.gameObject)
                 {
                     checker = true;
                     index = i;
                     break;
                 }
             }
             if (checker)
             {
                 if (bark.myData[index].hitBottom)
                 {
                     bark.myData[index].hitTop = false;
                     bark.check(bark.myData[index]);
                 }
                 else
                 {
                     bark.myData[index].hitTop = false;
                     bark.check(bark.myData[index]);
                     bark.myData.Remove(bark.myData[index]);
                 }
             }
         }
         if (c.gameObject.tag == "Respawn")
         {
             bool checker = false;
             int index = 0;
             for (int i = 0; i < bark.myData.Count; i++)
             {
                 if (bark.myData[i].obj == c.gameObject)
                 {
                     checker = true;
                     index = i;
                     break;
                 }
             }
             if (checker)
             {
                 if (bark.myData[index].hitBottom)
                 {
                     bark.myData[index].hitTop = false;
                     bark.checkEnemies(bark.myData[index]);
                 }
                 else
                 {
                     bark.myData[index].hitTop = false;
                     bark.checkEnemies(bark.myData[index]);
                     bark.myData.Remove(bark.myData[index]);
                 }
             }
         }
     }

     public void OnTriggerEnter2D(Collider2D c)
     {
         if (c.gameObject.tag == "Player")
         {
             bool checker = false;
             int index = 0;
             for (int i = 0; i < bark.myData.Count; i++)
             {
                 if (bark.myData[i].obj == c.gameObject)
                 {
                     checker = true;
                     index = i;
                     break;
                 }
             }
             if (checker)
             {
                 bark.myData[index].hitTop = true;
                 bark.check(bark.myData[index]);
                 Debug.Log(bark.myData[index].obj.name);
             }
             else
             {
                 renderData data = new renderData();
                 data.obj = c.gameObject;
                 data.hitTop = true;
                 data.sprite = c.transform.parent.GetComponent<SpriteRenderer>();
                 bark.myData.Add(data);
                 bark.check(data);
             }
         }
         if (c.gameObject.tag == "Respawn")
         {
             bool checker = false;
             int index = 0;
             for (int i = 0; i < bark.myData.Count; i++)
             {
                 if (bark.myData[i].obj == c.gameObject)
                 {
                     checker = true;
                     index = i;
                     break;
                 }
             }
             if (checker)
             {
                 bark.myData[index].hitTop = true;
                 bark.checkEnemies(bark.myData[index]);
                 Debug.Log(bark.myData[index].obj.name);
             }
             else
             {
                 renderData data = new renderData();
                 data.obj = c.gameObject;
                 data.hitTop = true;
                 data.sprite = c.transform.parent.GetComponent<SpriteRenderer>();
                 bark.myData.Add(data);
                 bark.checkEnemies(data);
             }
         }
     }*/

    /* public bool hit;

     public Bark bark;

     public SpriteRenderer sprite;

     public void OnTriggerExit2D(Collider2D c)
     {
         if (c.gameObject.tag=="Player")
         {
             hit = false;
             check();
         }
     }

     public void check()
     {
         if (bark.hit)
         {

             sprite.sortingOrder = 5;
             sprite.color = new Color(1, 1, 1, 1);
         }
         else
         {
             if (hit)
             {
                 sprite.sortingOrder = 20;
                 sprite.color = new Color(1, 1, 1, 0.3f);
             }
             else
             {
                 sprite.sortingOrder = 5;
                 sprite.color = new Color(1, 1, 1, 1);
             }
         }

     }

     public void OnTriggerEnter2D(Collider2D c)
     {
         if (c.gameObject.tag == "Player")
         {
             hit = true;
             check();
         }
     }*/
}
