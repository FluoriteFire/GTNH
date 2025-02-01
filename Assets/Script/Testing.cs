using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
    public Transform parent;
    public GameObject test;
    private List<List<Grid>> grid; 
    private int length = 10;
    private void Start()
    {
        // grid = new Grid(length,length,10f,parent,new Vector3(0,0,0));
        grid = new List<List<Grid>>();
        for(int i = 0; i < 3; i++)
        {
            grid.Add(new List<Grid>());
            for(int j = 0; j < 3; j++)
            {
                grid[i].Add(new Grid(length,length,10f,parent,new Vector3(10f * length * i, 0, 10f * length * j)));
            }
        }
    }

    public void Build(MachineObject obj)
    {
        obj.gameObject = Instantiate(obj.machine.machineObject, grid[obj.blockX][obj.blockY].GetWorldPostion(obj.positionX,0,obj.positionY)+new Vector3(5,5,5),Quaternion.identity);
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            int x,y;
            Vector3 worldposition;
            worldposition = utils.GetMouseWorldPosition();
            utils.GetBlockXY(worldposition,out x,out y);

            int i,j;
            grid[x][y].GetXY(worldposition,out i,out j);
            int index= grid[x][y].GetValue(i,j);
            if(index != 0)      return;
            grid[x][y].SetValue(i,j,42);

        
            MachineObject obj = new MachineObject(DataMachine.dataMachine["Assembler"],0,i,j,x,y);
            grid[x][y].SetMachine(i,j,obj);
            Build(obj);
        }
        if(Input.GetMouseButtonDown(1))
        {
            int x,y;
            Vector3 worldposition;
            worldposition = utils.GetMouseWorldPosition();
            utils.GetBlockXY(worldposition,out x,out y);

            MachineObject obj = grid[x][y].GetMachine(worldposition);
            if(obj != null)
            {
                Debug.Log(obj.machine.machineName);
                int i,j;
                grid[x][y].GetXY(worldposition,out i,out j);
                grid[x][y].DelMachine(i,j);

                Destroy(obj.gameObject);

                grid[x][y].SetValue(i,j,0);
            }
            else
            {
                int i,j;
                grid[x][y].GetXY(worldposition,out i,out j);
                int index= grid[x][y].GetValue(i,j);
                if(index != 0)      return;
                grid[x][y].SetValue(i,j,20);
                obj = new MachineObject(DataMachine.dataMachine["Box"],0,i,j,x,y);
                grid[x][y].SetMachine(i,j,obj);
                Build(obj);
            }
        }
    }
}