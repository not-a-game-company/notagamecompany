using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    protected NavMeshAgent navMeshagent;

    public void Start()
    {
        navMeshagent = this.GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Team1");
	
    }

    private void Update()
    {
        navMeshagent.SetDestination(target.transform.position);
	
    }

}
