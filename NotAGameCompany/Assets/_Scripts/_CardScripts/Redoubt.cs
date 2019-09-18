using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redoubt : CardBasicActions
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookToMouse(transform);
    }

    protected override void PerformAction()
    {
        Debug.Log("Digging Away Sir");
    }
}
