using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Data", menuName ="ScriptableObjects/QuestHolder", order =1)]
public class QuestHolder : ScriptableObject {

    public int reqsNotMetNode;

    public string startQuest = " I can start this quest by talking to ---- who is located in ----";

    public bool started;

    public bool completed;

    public string questName;

    public int stepNum;

    public int textIndex;

   // public int lineNum;

    //for sentences in our text asset
    public int[] steplist;

    public TextAsset mytext;

    public int startNode;

    public int endNode;


    public List<QuestHolder> reqs = new List<QuestHolder>();

    public string reqString;

    //for setting which node we should start on based on our step num?
    public int[] nodeList;

    public int[] alternateNodeList;

    public List<npcData> npcDataStorage;
}
[System.Serializable]
public class npcData
{
    public string NpcName;

    public int stepNum;

    public int[] nodeList;

    public int[] alternateNodeList;

    public int endNode;
}