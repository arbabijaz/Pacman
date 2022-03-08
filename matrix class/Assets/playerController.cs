using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public PacManView grid;
    public CellView CellView;
    private int row;
    private int col;
    private int currrow = 0;
    private int currcol =0;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("initilze", 1);
    }
    
    void initilze()
    {
        this.transform.position = grid.cells[0][0].transform.position + new Vector3(0, 0.5f, 0);
        row = grid.row;
        col = grid.col;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currcol >= 0 && currcol < col)
            {

                if (currcol != 0)
                {
                    currcol--;
                }
                setPlayerPos();

            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (currcol >= 0 && currcol < col)
            {
                if (currcol < col - 1)
                {
                    currcol++;
                }

                setPlayerPos();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (currrow >= 0 && currrow < row)
            {
                if (currrow != 0)
                {
                    currrow--;
                }

                setPlayerPos();
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (currrow >= 0 && currrow < row)
            {
                if (currrow < row - 1)
                {
                    currrow++;
                }
                setPlayerPos();
            }
        }
    }
    
    void setPlayerPos()
    {
        this.transform.position = grid.cells[currrow][currcol].transform.position + new Vector3(0, 0.5f, 0);
        grid.cells[currrow][currcol].GetComponent<CellView>().cellViewIntrection();
    }
    
}