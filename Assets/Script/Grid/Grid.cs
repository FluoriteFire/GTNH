using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    private MachineObject[,] machines;
    
    //  初始化一个Grid对象
    public Grid(int width, int height, float cellSize, Transform parent, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width,height];
        machines = new MachineObject[width,height];
        debugTextArray = new TextMesh[width,height];
        
        // 画边框
        for(int x = 0; x < gridArray.GetLength(0); ++x)
        {
            for(int y = 0; y < gridArray.GetLength(1); ++y)
            {
                debugTextArray[x,y] = utils.CreateWorldText(parent,gridArray[x,y].ToString(),GetWorldPostion(x,0,y) + new Vector3(cellSize,0,cellSize) * 0.5f,20,Color.white,TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPostion(x,0,y), GetWorldPostion(x,0,y+1),Color.white,100f);
                Debug.DrawLine(GetWorldPostion(x,0,y), GetWorldPostion(x+1,0,y),Color.white,100f);
            }
        }
        Debug.DrawLine(GetWorldPostion(0,0,height), GetWorldPostion(width,0,height),Color.white,100f);
        Debug.DrawLine(GetWorldPostion(width,0,0), GetWorldPostion(width,0,height),Color.white,100f);
    }

    // 由xyz坐标获取世界坐标
    public Vector3 GetWorldPostion(int x=0, int y=0, int z=0)
    {
        return new Vector3(x,y,z) * cellSize + originPosition;
    }
    
    // 从世界坐标获取xy的坐标值
    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition-originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition-originPosition).z / cellSize);
    }

    // 设置格子xy的值(text)
    public void SetValue(int x, int y, int value)
    {
        if(x>=0 && y>=0 && x<width && y<height)
        {
            gridArray[x,y] = value;
            debugTextArray[x,y].text = gridArray[x,y].ToString();
        }
    }

    // 从世界坐标设置格子的值
    public void SetValue(Vector3 worldPosition, int value)
    {
        int x,y;
        GetXY(worldPosition,out x,out y);
        SetValue(x,y,value);
    }
    
    // 从xy坐标获取设置的值
    public int GetValue(int x, int y)
    {
        if(x>=0 && y>=0 && x<width && y<height)
        {
            return gridArray[x,y];
        }
        else 
        {
            return -1;
        }
    }

    // 从世界坐标获取设置的值
    public int GetValue(Vector3 worldPosition)
    {
        int x,y;
        GetXY(worldPosition,out x,out y);
        return GetValue(x,y);
    }

    public void SetMachine(int x, int y, MachineObject obj)
    {
        if(x>=0 && y>=0 && x<width && y<height)
        {
            machines[x,y] = obj;
        }
    }

    public MachineObject GetMachine(int x, int y)
    {
        if(x>=0 && y>=0 && x<width && y<height)
        {
            return machines[x,y];
        }
        else 
        {
            return null;
        }
    }

    public MachineObject GetMachine(Vector3 worldPosition)
    {
        int x,y;
        GetXY(worldPosition,out x,out y);
        return GetMachine(x,y);
    }

    public void DelMachine(int x, int y)
    {
        if(x>=0 && y>=0 && x<width && y<height)
        {
            machines[x,y] = null;
        }
    }
}