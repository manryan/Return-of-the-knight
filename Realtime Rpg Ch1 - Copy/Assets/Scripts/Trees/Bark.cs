using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour {


   /* public List<renderData> myData = new List<renderData>();

    public SpriteRenderer sprite;

    public SpriteRenderer spriteOrderRef;

    public void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            bool checker = false;
            int index = 0;
            for (int i = 0; i < myData.Count; i++)
            {
                if (myData[i].obj == c.gameObject)
                {
                    checker = true;
                    index = i;
                    break;
                }
            }
            if (checker)
            {
                if (myData[index].hitTop)
                {
                    myData[index].hitBottom = false;
                    check(myData[index]);
                }
                else
                {
                    myData[index].hitBottom = false;
                    check(myData[index]);
                    myData.Remove(myData[index]);
                }
            }
        }
        if (c.gameObject.tag == "Respawn")
        {
            bool checker = false;
            int index = 0;
            for (int i = 0; i < myData.Count; i++)
            {
                if (myData[i].obj == c.gameObject)
                {
                    checker = true;
                    index = i;
                    break;
                }
            }
            if (checker)
            {
                if (myData[index].hitTop)
                {
                    myData[index].hitBottom = false;
                    checkEnemies(myData[index]);
                }
                else
                {
                    myData[index].hitBottom = false;
                    checkEnemies(myData[index]);
                    myData.Remove(myData[index]);
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
            for (int i = 0; i < myData.Count; i++)
            {
                if(myData[i].obj == c.gameObject)
                {
                    checker = true;
                    index = i;
                    break;
                }
            }
                if(checker)
                {
                myData[index].hitBottom = true;
                check(myData[index]);
               Debug.Log( myData[index].obj.name);
                }
                else
            {
                renderData data = new renderData();
                data.obj = c.gameObject;
                data.hitBottom = true;
                data.sprite = c.transform.parent.GetComponent<SpriteRenderer>();
                myData.Add(data);
                check(data);
            }
        }
        if (c.gameObject.tag == "Respawn")
        {
            bool checker = false;
            int index = 0;
            for (int i = 0; i < myData.Count; i++)
            {
                if(myData[i].obj == c.gameObject)
                {
                    checker = true;
                    index = i;
                    break;
                }
            }
                if(checker)
                {
                myData[index].hitBottom = true;
                checkEnemies(myData[index]);
               Debug.Log( myData[index].obj.name);
                }
                else
            {
                renderData data = new renderData();
                data.obj = c.gameObject;
                data.hitBottom = true;
                data.sprite = c.transform.parent.GetComponent<SpriteRenderer>();
                myData.Add(data);
                checkEnemies(data);
            }
        }
    }

    
    public void check(renderData data)
    {
        if (data.hitBottom)
        {

            data.sprite.sortingOrder = spriteOrderRef.sortingOrder+1;
            if(sprite)
            sprite.color = new Color(1, 1, 1, 1);
        }
        else
        {
            if (data.hitTop)
            {
                data.sprite.sortingOrder = spriteOrderRef.sortingOrder -1;
                if (sprite)
                    sprite.color = new Color(1, 1, 1, 0.3f);
            }
            else
            {

                data.sprite.sortingOrder = spriteOrderRef.sortingOrder + 1;
                if (sprite)
                    sprite.color = new Color(1, 1, 1, 1);
            }
        }

    }
    public void checkEnemies(renderData data)
    {
        if (data.hitBottom)
        {

            data.sprite.sortingOrder = 20;
        }
        else
        {
            if (data.hitTop)
            {
                data.sprite.sortingOrder = 14;
            }
            else
            {

                data.sprite.sortingOrder = 20;
            }
        }

    }
    */


    /*  public bool hit;

      public Leaves leaves;

      public void OnTriggerExit2D(Collider2D c)
      {
          if (c.gameObject.tag == "Player")
          {
              hit = false;
              leaves.check();
          }
      }

      public void OnTriggerEnter2D(Collider2D c)
      {
          if (c.gameObject.tag == "Player")
          {
              hit = true;
              leaves.check();
          }
      }*/
}
/*
[System.Serializable]
public class renderData
{
    public bool hitTop;

    public bool hitBottom;

    public GameObject obj;

    public SpriteRenderer sprite;
}*/