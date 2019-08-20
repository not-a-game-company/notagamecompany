using UnityEngine;


public class PlayGrid : MonoBehaviour
{
    [SerializeField] [Range(1,5)] private float size = 1f;
    [SerializeField] private int rangeX = 40;
    [SerializeField] private int rangeZ = 40;
    [SerializeField] private GameObject sphereMaker;

    private bool online;
    private void LateUpdate()
    { 
  
        BallPit();
    }


   public void BallPit()
    {
        for (float x = 0; x < rangeX; x += size)
        {
            for (float z = 0; z < rangeZ; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Instantiate(sphereMaker, point, Quaternion.identity);
              
            }
        }
    }
   
   public Vector3 GetNearestPointOnGrid(Vector3 position)
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