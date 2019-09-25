using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;


public enum thetype { Bool = 1, Int}

public class Dialogue : MonoBehaviour
{

}


   /* public TextAsset mytext;

    public TextAsset playertext;

    public string[] words;

    public string[] playerwords;

    public Text testText;

    public int index = 0;

    public bool started;

    public bool complete;

    public Button accept;

    public Button decline;

    public int interactionNum;

    public string[] functionNumber;



    public void Start()
    {
         words = mytext.text.Split(
    new[] { "\r\n", "\r", "\n" },
    System.StringSplitOptions.None
);


        StartCoroutine(loadSentance(index));

    }

    public IEnumerator loadSentance(int line)
    {
        string[] test = words[line].Split(" "[0]);
         for (int i = 0; i < test.Length; i++)
  {
            if(i>0)
            testText.text += " ";
           testText.text += test[i];
            yield return new WaitForSeconds(1);
  }
        index++;
    }

    public void assignButtons()
    {

    }

    public void Continue()
    {
        if (index == interactionNum)


        if(index > words.Length-1)
        loadSentance(index);
        else
        {
            loadButtons();
        }
    }

    public void Confirm()
    {
        testText.text = "Wonderful, lets start right away";
    }

    public void Reject()
    {
        testText.text = "Oh dear i guess another time";
    }

    public void loadButtons()
    {
        accept.gameObject.SetActive(true);
        decline.gameObject.SetActive(true);

        accept.onClick.AddListener(Confirm);
        decline.onClick.AddListener(Reject);
    }
}
*/