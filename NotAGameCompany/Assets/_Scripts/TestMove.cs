using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TestMove : Bolt.EntityBehaviour<IUnitMove>
{ 
	[SerializeField] protected GameObject target;

	[SerializeField] [Range(1, 100)] private int stoppingDistance = 2;
	protected NavMeshAgent navMeshagent;
	
	
	public void Start()
	{
		navMeshagent = this.GetComponent<NavMeshAgent>();
		target = GameObject.FindWithTag("Team1");
	
	
	}

	private void Update()
	{
		if(StartTimer.countDownTimer >= 0) return;
		navMeshagent.stoppingDistance = stoppingDistance;
		navMeshagent.SetDestination(target.transform.position);
	}

}
