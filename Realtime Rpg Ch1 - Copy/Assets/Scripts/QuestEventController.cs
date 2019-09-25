using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VIDE_Data;

public class QuestEventController : MonoBehaviour
{
    public GameObject[] objectsToDisable;

    public UiController ui;

    public Camera cam;

    public UnityEvent cinematicEvent;

    public UnityEvent eventEnds;

    public Transform pos;

    public int nodeToLoad;

    public void disableObj(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void fadeoutObj(int num)
    {
        StartCoroutine(fadeOutObject(num));
    }

    public IEnumerator fadeOutObject(int num)
    {
        SpriteRenderer sprite = objectsToDisable[num].GetComponent<SpriteRenderer>();

        var col = 1f;
        while (col>0f)
        {
            col -= 0.0125F;
            sprite.color = new Color(1, 1, 1, col);
            yield return null;
        }
        float time = 3f;
        while(time>0f)
        {
            time -= 0.1f;
            yield return null;
        }
        objectsToDisable[num].SetActive(false);
        cam.transform.position = new Vector3(GameManager.instance.player.transform.position.x, GameManager.instance.player.transform.position.y, cam.transform.position.z);
        if (eventEnds != null)
            eventEnds.Invoke();

        //GameManager.instance.player.returnDialogue();
    }

    public void moveCamMethod()
    {
        Debug.Log("????");
        StartCoroutine(moveCam());
    }

    public IEnumerator moveCam()
    {
     //   GameManager.instance.player.moveDialogue();
        Time.timeScale = 0;
        while(cam.transform.position!= new Vector3(pos.position.x, pos.position.y, cam.transform.position.z))
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(pos.position.x, pos.position.y, cam.transform.position.z), 0.1f);
            yield return null;
        }
        cinematicEvent.Invoke();
    }
}
