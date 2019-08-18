using System;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour 
{
    public List<GameObject> listOfSeletcableAssests;
    public HotbarButton hotbarbuttonSetInfo;
    public bool ready = false;
    [SerializeField] private GameObject hotBarbuttonPrefab;


    private void Awake()
    {
        for (int i = 0; i < listOfSeletcableAssests.Count; i++)
        {
            Debug.Log("Making buttons chief for: " + listOfSeletcableAssests[i].name);
            var hotBarbuttonNeedsToBecomeChild =
                Instantiate(hotBarbuttonPrefab, transform.position, Quaternion.identity);

            hotBarbuttonNeedsToBecomeChild.transform.parent = gameObject.transform;
        }
    }

    //https://docs.unity3d.com/ScriptReference/PrefabUtility.InstantiatePrefab.html
   //assign image to prefab
}

//make resources fold and put in fold and load list of prefabs at runtime. Avoids all this nonsense 
