using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsPool : MonoBehaviour {

    public GameObject fx;

    public int pooledAmount;

    public List<GameObject> fxs = new List<GameObject>();


    public bool shouldExpand = true;

    public GameObject GetFx()
    {
        for (int i = 0; i < fxs.Count; i++)
        {
            //is it active in scene?
            if (!fxs[i].activeInHierarchy)
            {
                return fxs[i];
            }
        }
        if (shouldExpand)
        {
            GameObject obj = (GameObject)Instantiate(fx);
             obj.SetActive(false);
            fxs.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }
}
