using UnityEngine;

public class Combativeness : TestMove
{
    [SerializeField] [Range(1,100)] private int damage = 3;
    [SerializeField] [Range(1,100)] private int attackRange = 1;
    void Update()
    {
        if (navMeshagent == null) return;
        if (navMeshagent.remainingDistance <= attackRange)
        {
            target.GetComponent<VitalityState>().health -= damage; 
        }
    }
}
