using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManGrid : Matrix
{
    List<List<Cell>> cell;
    List<List<float>> testMatrix = new List<List<float>>();
    

    public delegate void OnGridUpdate();
    public OnGridUpdate onGridUpdate;

    public delegate void OnCellCreated(Cell cell);
    public OnCellCreated onCellCreated;
    //testMatr
    public PacManGrid(int row, int col) : base(row, col)
    {
        cell = new List<List<Cell>>();
    }
    public PacManGrid(int[,] arr) : base(arr)
    {

    }
    public void InitializeCells()
    {
        for (int i = 0; i < numOfRows; i++)
        {
            cell.Add(new List<Cell>());
            for (int j = 0; j < numOfCols; j++)
            {
                Cell tempCell = new Cell(i, j);
                tempCell.onStatusSetRequest += CellStatusSetRequest;
                cell[i].Add(tempCell);
                onCellCreated?.Invoke(cell[i][j]);
                if (i == 0 || i == numOfRows - 1 || j == 0 || j == numOfCols - 1)
                {
                    SetElement(i, j, (int)Cell.Status.check);
                    cell[i][j].setStatus(Cell.Status.check);
                }
                else
                {
                    SetElement(i, j, (int)Cell.Status.none);
                }
                
            }
        }
    }
    public void CellStatusSetRequest(int row, int col)
    {
        
        if (GetElement(row,col)==0&&!CheckMatrixData() )
        {
            SetElement(row, col, (int)Cell.Status.check);
            cell[row][col].setStatus(Cell.Status.check);
        }
        else if (CheckMatrixData())
        {
            Debug.Log("You Won");
        }
        
    }
    
    

    public bool CheckMatrixData()
    {
        int totelVisted = 0;
        int totelcell = numOfCols*numOfRows;
        float perc = 0;
        bool won = false;
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfCols; j++)
            {
                if (matrixx[i][j] == 1)
                {
                    totelVisted++;
                }
            }
        }
        perc = totelVisted / totelcell;
        perc *= 100;
        if (perc >= 70)
        {
            
            return true;
        }
        return won;
    }
   
}
