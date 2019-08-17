using UnityEngine;
using UnityEngine.Networking;

public class AssetsPlacer : NetworkBehaviour 
{

	public static GameObject selectedAssest;
	private PlayGrid _playGrid;
	private LayerMask planeForMouseRayProtector; //keeps the mouse plane for the ray from getting deleted in the level editor grid.
	
	private void Awake()
	{
		_playGrid = FindObjectOfType<PlayGrid>();
		planeForMouseRayProtector = ~(1<<LayerMask.NameToLayer("PlayGrid"));
	}
    
	private void Update()
	{
		MouseInput();
	}

	public  void MouseInput()
	{
		CmdMouseInput();
	}

	[Command]
	public void CmdMouseInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(MouseController.Ray, out MouseController.HitInfo))
			{
				CmdPlaceAssest(MouseController.HitInfo.point);
			}
		}

		if (Input.GetMouseButtonDown(1))
		{
			if (Physics.Raycast(MouseController.Ray, out MouseController.HitInfo, Mathf.Infinity, planeForMouseRayProtector)
			) // need to prevent this from deleting the plane that detects the mouse, layers will fix this
			{
				Destroy(MouseController.HitInfo.collider.gameObject);
			}
		}
	}

	[Command]
	public void CmdPlaceAssest(Vector3 clickPoint)
	{
		var finalPosition = _playGrid.CmdGetNearestPointOnGrid(clickPoint); 
		if (selectedAssest == null){return;}
		GameObject instanitatedSelectedAssest = Instantiate(selectedAssest, finalPosition, Quaternion.identity);
		//GameObject owner = this.gameObject;
		//NetworkServer.SpawnWithClientAuthority(instanitatedSelectedAssest, owner);
		NetworkServer.Spawn(instanitatedSelectedAssest);
	}

	[ClientRpc]
	void RpcPlaceAssest()
	{
		if (!isServer)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (Physics.Raycast(MouseController.Ray, out MouseController.HitInfo))
				{
					CmdPlaceAssest(MouseController.HitInfo.point);
				}
			}

			if (Input.GetMouseButtonDown(1))
			{
				if (Physics.Raycast(MouseController.Ray, out MouseController.HitInfo, Mathf.Infinity, planeForMouseRayProtector)
				) // need to prevent this from deleting the plane that detects the mouse, layers will fix this
				{
					Destroy(MouseController.HitInfo.collider.gameObject);
				}
			}
		}
	}


}
