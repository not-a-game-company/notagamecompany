using UnityEngine;

public class CardBasicActions : MonoBehaviour
{
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    protected void LookToMouse(Transform transform)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo) && Input.GetMouseButtonDown(0))
        {
            if (transform != hitInfo.transform) return;
            PerformAction(); 
        }
    }

    protected virtual void PerformAction()
    {
        Debug.Log("Action to Be Performed not declared! Refer to CarBasicsActions script");
    }
}
