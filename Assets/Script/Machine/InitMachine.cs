using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMachine : MonoBehaviour
{
    public GameObject Box;
    public GameObject Machine;
    void Start()
    {
        // DataMachine.dataMachine.Add("箱子", new Machine(Box,"箱子"));
        // DataMachine.dataMachine.Add("机器", new Machine(Machine,"机器"));

        var jsonTextFile = Resources.LoadAll<TextAsset>("Machine");
        for(int i = 0; i < jsonTextFile.Length; i++)
        {
            var text = jsonTextFile[i].ToString();
            Machine m = JsonUtility.FromJson<Machine>(text);
            m.machineObject = Resources.Load<GameObject>("Prefab/"+m.machineName);
            // Resources.Load("enemy", typeof(GameObject))

            DataMachine.dataMachine.Add(m.machineName, m);
        }
    }
}
