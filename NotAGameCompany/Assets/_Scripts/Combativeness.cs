using UnityEngine;

public class Combativeness : TestMove
{
    [SerializeField] [Range(1,100)] private int damage = 3;
    void Update()
    {
        if (navMeshagent.remainingDistance <= 2)
        {
            target.GetComponent<VitalityState>().health -= damage; 
        }

    }
}
