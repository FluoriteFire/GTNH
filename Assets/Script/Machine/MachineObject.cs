using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineObject
{
    public GameObject gameObject;
    public Machine machine;
    public int machineFace;             // 机器面向 0东 1南 2西 3北
    public int positionX;
    public int positionY;
    public int blockX;
    public int blockY;

    public MachineObject(Machine machine, int machineFace, int positionX, int positionY, int blockX, int blockY)
    {
        this.machine = machine;
        this.machineFace = machineFace;
        this.positionX = positionX;
        this.positionY = positionY;
        this.blockX = blockX;
        this.blockY = blockY;
    }
}
