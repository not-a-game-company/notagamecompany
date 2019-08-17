using UnityEngine;
using UnityEngine.Networking;

public class PlayGrid : NetworkBehaviour
{
    [SerializeField] [Range(1,5)] private float size = 1f;
    [SerializeField] private int rangeX = 40;
    [SerializeField] private int rangeZ = 40;
    [SerializeField] private GameObject sphereMaker;
	
    private void Update()
    {
        OnDrawBallPit();
    }

    private void OnDrawBallPit()
    {
        CmdBallPit();
    }

   // [Command]
    public void CmdBallPit()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < rangeX; x += size)
        {
            for (float z = 0; z < rangeZ; z += size)
            {
                var point = CmdGetNearestPointOnGrid(new Vector3(x, 0f, z));
                //Gizmos.DrawSphere(point, 0.1f);
                GameObject ballPit = Instantiate(sphereMaker, point, Quaternion.identity);
                NetworkServer.Spawn(ballPit);
            }
        }
    }

    //[Command]
    public Vector3 CmdGetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);
		
        Vector3 result = new Vector3(
            (float)xCount * size, 
            (float)yCount * size,
            (float)zCount * size);

        result += transform.position;
		
        return result;
    }

}