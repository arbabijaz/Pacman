using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpowning : MonoBehaviour
{
    public GameObject cube;
    public float horizontalSpac = -6;
    public float verticalSpace = -4;
    public List<List<GameObject>> cells = new List<List<GameObject>>();
    public int row = 4;
    public int col = 3;
    void Start()
    {
        gridSpowning();
    }
    public void gridSpowning()
    {
        //cells = new List<List<GameObject>>();
        Debug.Log("spawn");
        float temp = horizontalSpac;
        for (int i = 0; i < row; i++)
        {
            cells.Add(new List<GameObject>());
            for (int j = 0; j < col; j++)
            {
                cube=Instantiate(cube, new Vector3(horizontalSpac, 0, verticalSpace), cube.transform.rotation);
                cells[i].Add(cube);

                horizontalSpac += 1.1f;
                
            }
            verticalSpace -= 1.1f;
            horizontalSpac = temp;
            
        }
        
    }
   
}
