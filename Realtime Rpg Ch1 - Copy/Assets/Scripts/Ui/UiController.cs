using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using VIDE_Data;

public class UiController : MonoBehaviour {

    public Text hideText;

    public Button reduceButton;

    public ObjectPoolingManager objpool;

    public void Start()
    {
        GameManager.instance.player= GameObject.Find("Update/Player").GetComponent<Player>();
        GameManager.instance.player.objPoolManager = objpool;
    }

    public void loadScene(string name)
    {
        if (name == "saving")
            Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

	public void closeJournal(GameObject journal)
    {
        if (journal.activeInHierarchy)
        {
            Time.timeScale = 1;
            journal.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            journal.SetActive(true);
        }
    }
    public void closeReward(GameObject journal)
    {
        if (journal.activeInHierarchy)
        {
            Time.timeScale = 1;
            journal.SetActive(false);
            GameManager.instance.player.returnDialogue();
        }
        else
        {
            Time.timeScale = 0;
            journal.SetActive(true);
        }
    }

    public void hide(RectTransform obj)
    {
        if(obj.position.x<4f)
        { 
            obj.position = new Vector2(obj.transform.position.x + 5f, obj.transform.position.y - 1000f);
            hideText.text = "+";
            reduceButton.gameObject.SetActive(false);
        }
        else
        {
            obj.position = obj.parent.transform.position;
            hideText.text = "-";
            reduceButton.gameObject.SetActive(true);
        }
    }
}
