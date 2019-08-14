using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TestMove : MonoBehaviour
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
