using UnityEngine;

public class AssetsPlacer : MonoBehaviour 
{

	public static GameObject selectedAssest;
	private Grid _grid;
	private LayerMask planeForMouseRayProtector; //keeps the mouse plane for the ray from getting deleted in the level editor grid.
	private void Awake()
	{
		_grid = FindObjectOfType<Grid>();
		planeForMouseRayProtector = ~(1<<LayerMask.NameToLayer("Grid"));
	}
    
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{   
			if (Physics.Raycast(MouseController.Ray, out MouseController.HitInfo))
			{
				PlaceAssest(MouseController.HitInfo.point);
			}
            
		}
		if (Input.GetMouseButtonDown(1)) 
		{
			if (Physics.Raycast(MouseController.Ray, out MouseController.HitInfo, Mathf.Infinity,planeForMouseRayProtector))// need to prevent this from deleting the plane that detects the mouse, layers will fix this
			{
				Destroy(MouseController.HitInfo.collider.gameObject);
			} 
		}
	}
    
	private void PlaceAssest(Vector3 clickPoint)
	{
		var finalPosition = _grid.GetNearestPointOnGrid(clickPoint);
		if (selectedAssest == null){return;}
		Instantiate(selectedAssest, finalPosition, Quaternion.identity);
	}
}
