using UnityEngine;
using UnityEngine.Networking;

public class MouseController : MonoBehaviour
{
       private RaycastHit hitInfo;
       private Ray ray;
       public static Ray Ray;
       public static RaycastHit HitInfo;
       public GameObject sphereMaker;
       private void Update()
       {
           LookToMouse();
       }

       private void LookToMouse()
       {    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            HitInfo = hitInfo;
                            Ray = ray;
              if (Physics.Raycast(Ray, out HitInfo))
              {
                    Vector3 newpoint = new Vector3(HitInfo.point.x, transform.position.y, HitInfo.point.z);
                               transform.LookAt(newpoint); 

              }
       }
}
