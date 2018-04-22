using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //gameobject for spawning 
    public GameObject spawnObj;
    //set custom range for random position
    public float MinX = -10;
    public float MaxX = 10;
    public float MinY = -10;
    public float MaxY = 10;

    //for 3d you have z position
    public float MinZ = -10;
    public float MaxZ = 10;

    public void SpawnObject()
    {
        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);
        float z = Random.Range(MinZ, MaxZ);

        var pl = Instantiate(spawnObj, new Vector3(x, 0, z), Quaternion.identity) as GameObject;
 
    }
}
