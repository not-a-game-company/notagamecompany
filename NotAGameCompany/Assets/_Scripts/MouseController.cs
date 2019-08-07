using UnityEngine;
public class MouseController : MonoBehaviour
{
       private RaycastHit hitInfo;
       private Ray ray;

       public static Ray Ray;
       public static RaycastHit HitInfo; //Should I be using a get and set? I only ever want one mouse and its info. I think this is ok, unless I implement 2 player
       
       private void Update()
       {
              ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              HitInfo = hitInfo;
              Ray = ray; 
              LookToMouse();
       }
       private void LookToMouse()
       {		
              if (Physics.Raycast(Ray, out HitInfo))
              {
                     Vector3 newpoint = new Vector3(HitInfo.point.x, transform.position.y, HitInfo.point.z);
                     transform.LookAt(newpoint);
              }
       }
}
