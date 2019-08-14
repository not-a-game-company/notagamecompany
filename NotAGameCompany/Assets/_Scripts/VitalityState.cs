using UnityEngine;

public class VitalityState : MonoBehaviour
{
    [Range(1,100)] public int health = 5;
    
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("I'm ded");
        }
    }
}
