using UnityEngine;
using UnityEngine.Networking;

public class MouseController : NetworkBehaviour
{
       private RaycastHit hitInfo;
       private Ray ray;
       public static Ray Ray;
       public static RaycastHit HitInfo;
       public GameObject sphereMaker;
       private void Update()
       {
             LookToMouse();
             CmdnewPoint();
       }

       private void LookToMouse()
       {    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            HitInfo = hitInfo;
                            Ray = ray;
              if (Physics.Raycast(Ray, out HitInfo))
              {
                    Vector3 newpoint = new Vector3(HitInfo.point.x, transform.position.y, HitInfo.point.z);
                               transform.LookAt(newpoint); 
                               GameObject ballPit = Instantiate(sphereMaker, newpoint, Quaternion.identity);
                               NetworkServer.Spawn(ballPit);
              }
       }

       [Command]
       void CmdnewPoint()
       {
           if(!isServer)
            RpcnewPoint();
       }

       [ClientRpc]
       void RpcnewPoint()
       {
          LookToMouse();
       }
}
