using UnityEngine;

public class AssetsPlacer : Bolt.EntityBehaviour<IClickToMoveState>
{

	public static GameObject selectedAssest;
	private PlayGrid _playGrid;
	private LayerMask planeForMouseRayProtector; //keeps the mouse plane for the ray from getting deleted in the level editor grid.
	
	private void Awake()
	{
		_playGrid = FindObjectOfType<PlayGrid>();
		//planeForMouseRayProtector = ~(1<<LayerMask.NameToLayer("PlayGrid"));
	}
    
	private void Update()
	{
		MouseInput();
	}
	
	public void MouseInput()
	{
		if (Input.GetMouseButtonDown(0) )
		{
			if (Physics.Raycast(MouseController.Ray, out MouseController.HitInfo))
			{
				placeAssest(MouseController.HitInfo.point);
			}
		}

		if (Input.GetMouseButtonDown(1) )
		{
			if (Physics.Raycast(MouseController.Ray, out MouseController.HitInfo, Mathf.Infinity, planeForMouseRayProtector)
			) // need to prevent this from deleting the plane that detects the mouse, layers will fix this
			{
				Destroy(MouseController.HitInfo.collider.gameObject);
			}
		}
	}

	public void placeAssest(Vector3 clickPoint)
	{
		var finalPosition = _playGrid.GetNearestPointOnGrid(clickPoint); 
		if (selectedAssest == null){return;}
		Instantiate(selectedAssest, finalPosition, Quaternion.identity);
		
	}
	
}
