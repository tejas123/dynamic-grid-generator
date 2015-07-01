using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicGridGenerator : MonoBehaviour
{
    public Text numOfRows;
    public Text numOfColumns;
    public RectTransform panelRow;
    public GameObject gridCell;
		
    public Transform grid;
		
    private int rowSize;
    private int columnSize;
		
		
    void Initialize()
    {
        rowSize = int.Parse(numOfRows.text);
        columnSize = int.Parse(numOfColumns.text);
    }
		
    public void ClearGrid()
    {
        for (int count = 0; count < grid.childCount; count++)
        {
            Destroy(grid.GetChild(count).gameObject);
        }
    }
		
    public void GenerateGrid()
    {
		
        ClearGrid();
				
        Initialize();
		
        GameObject cellInputField;
        RectTransform rowParent;
        for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
        {
            rowParent = (RectTransform)Instantiate(panelRow);
            rowParent.transform.SetParent(grid);
            rowParent.transform.localScale = Vector3.one;
            for (int colIndex = 0; colIndex < columnSize; colIndex++)
            {
                cellInputField = (GameObject)Instantiate(gridCell);
                cellInputField.transform.SetParent(rowParent);
                cellInputField.GetComponent<RectTransform>().localScale = Vector3.one;		
            }
        }
    }
}
