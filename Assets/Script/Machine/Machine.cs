using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Machine
{
    [NonSerialized]
    public GameObject machineObject;    // 机器模型
    public string machineName;          // 机器名字

    // 是否机器

    // 机器类型 ：处理的配方什么的
    // 机器等级

    public bool isContainer;            // 是否有容器
    public int ContainerSize;           // 容器大小
    

    public Machine(GameObject machineObject, string machineName)
    {
        this.machineObject = machineObject;
        this.machineName = machineName;
    }
}
