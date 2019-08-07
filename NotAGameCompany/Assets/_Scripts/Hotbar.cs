using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour 
{
    public static List<GameObject> ListOfSelectableAsset; //can remove this
    public List<GameObject> listOfSeletcableAssests;
    //public List<GameObject> ListOfSelectableAssests;
    [SerializeField] private GameObject hotBarbuttonPrefab;
    [SerializeField] private int oldList;
    private void OnValidate()//maybe not the best idea, use on enable to get rid of the check
    {
        ListOfSelectableAsset = listOfSeletcableAssests;
        if (ListOfSelectableAsset.Count > oldList)
        {
            var hotBarbuttonNeedsToBecomeChild =
                Instantiate(hotBarbuttonPrefab, transform.position, Quaternion.identity);

            hotBarbuttonNeedsToBecomeChild.transform.parent = gameObject.transform;
        }
        oldList = ListOfSelectableAsset.Count;
    }
   //https://docs.unity3d.com/ScriptReference/PrefabUtility.InstantiatePrefab.html
   //assign image to prefab
}

//make resources fold and put in fold and load list of prefabs at runtime. Avoids all this nonsense 
/*
From Geoff Goeres-Hill (oDARKMATT3Ro) to Everyone: (10:21 PM)
 I really like the android native goodies package for what Chris was talking about:  https://assetstore.unity.com/packages/tools/integration/android-native-goodies-66662 
From Chris - DeadlyApps to Everyone: (10:22 PM)
 https://answers.unity.com/questions/61669/applicationopenurl-for-email-on-mobile.html 
*/