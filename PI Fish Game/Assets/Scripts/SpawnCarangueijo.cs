using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarangueijo : MonoBehaviour
{

    public GameObject enemy;

    void Start()
    {
        var spawnnedObject = Instantiate(enemy, transform);
        GameObject[] list = new GameObject[1];
        list[0] = spawnnedObject;
        spawnnedObject.GetComponent<InimigoMovimento>().grupo = list;
    }
}
