using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TestMove : MonoBehaviour
{ 
	[SerializeField] private Transform destination;

	[SerializeField] private int health = 5;
	[SerializeField] private int damage = 3; 
	
	private NavMeshAgent navMeshagent;

	public void Start()
	{
		navMeshagent = this.GetComponent<NavMeshAgent>();

		if (navMeshagent == null)
		{
			Debug.LogError("Nav Mesh Agent component not found attached to " + gameObject.name);
		}
		else
		{ 
			SetDestination();
		}
	}

	private void SetDestination()
	{
		if (destination != null)
		{
			Vector3 targetVector = destination.transform.position;

			navMeshagent.SetDestination(targetVector); 
		}
	}

	private void InAttackRange()
	{
		
	}
}
