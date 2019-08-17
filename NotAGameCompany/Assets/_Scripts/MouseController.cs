using UnityEngine;
using UnityEngine.Networking;

public class MouseController : NetworkBehaviour
{
       private RaycastHit hitInfo;
       private Ray ray;

       public static Ray Ray;

       public static RaycastHit
              HitInfo; //Should I be using a get and set? I only ever want one mouse and its info. I think this is ok, unless I implement 2 player

       private void Update()
       {
              CmdLookToMouseOnLine();
       }

       private void LookToMouse()
       {
              UpdatingCameraRayPos();
              if (Physics.Raycast(Ray, out HitInfo))
              {
                     Vector3 newpoint = new Vector3(HitInfo.point.x, transform.position.y, HitInfo.point.z);
                     transform.LookAt(newpoint);
                     
              }
       }

       private void UpdatingCameraRayPos()
       {
              ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              HitInfo = hitInfo;
              Ray = ray;
       }

       [Command]
       void CmdLookToMouseOnLine()
       {
              //UpdatingCameraRayPos();
              LookToMouse();
       }

       [ClientRpc]
       void RpcLookToMouse()
       {
              if(!isServer) 
                     LookToMouse();
       }

}
