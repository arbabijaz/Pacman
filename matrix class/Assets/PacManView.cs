using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManView : MonoBehaviour
{
    PacManGrid ticTacToeGrid;
    public GameObject cellPrefab;
    public int row;
    public int col;
    public float horizontalSpac;
    public float verticalSpace;
    int counter = 0;
    int counter2 = 0;
    public List<List<GameObject>> cells=new List<List<GameObject>>();
    private void Awake()
    {
        InitializeGrid();
    }
    private void Start()
    {
        
    }
    public void InitializeGrid()
    {
        ticTacToeGrid = new PacManGrid(row,col);
        ticTacToeGrid.onCellCreated += cellCreated;
        ticTacToeGrid.InitializeCells();
    }
    private void cellCreated(Cell cell)
    {
        InstentiatePosition();
        GameObject cellView = Instantiate(cellPrefab, new Vector3(horizontalSpac,0,verticalSpace),transform.rotation);
        
        cellView.GetComponent<CellView>().setCell(cell);
        cellView.GetComponent<CellView>().getCell().statusUpdate += cellView.GetComponent<CellView>().setStatus; //Set status of mono object cell in unity
        cells[counter2].Add(cellView);
        counter++;
    }
    void InstentiatePosition()
    {
        
        if (counter == col)
        {
            verticalSpace += 1.1f;
            counter = 0;
            counter2++;
            horizontalSpac = 3.1f;
        }
        else
        {
            horizontalSpac += 1.1f;
        }

        if (counter == 0)
        {
            cells.Add(new List<GameObject>());
        }
    }
}
