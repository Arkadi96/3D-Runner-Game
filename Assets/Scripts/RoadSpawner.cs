using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] roadGameObjects;
    [SerializeField]
    private Player player;
    
    private float zPos = 0f;
    private float zDistance;
    private Transform roadParentTransform = null;
    private Queue<GameObject> roadQueue = null;

    private void Start()
    {
        zDistance = roadGameObjects[1].transform.position.z;
        roadParentTransform = roadGameObjects[1].transform.parent;
        roadQueue = new Queue<GameObject>();

        foreach (var obj in roadGameObjects)
        {
            roadQueue.Enqueue(obj);
        }
        zPos = (roadQueue.Count - 1) * zDistance;
    }

    private void OnEnable()
    {
        player.OnLeftCheckPoint += SpawnRoad;
    }

    private void OnDisable()
    {
        player.OnLeftCheckPoint -= SpawnRoad;
    }

    private void SpawnRoad()
    {
        float z = GetRoadPos();
        GameObject oldRoad = roadQueue.Dequeue();
        var newRoad = Instantiate(oldRoad, new Vector3(0,0,zPos), Quaternion.identity);
        newRoad.transform.parent = roadParentTransform;
        Destroy(oldRoad);
        roadQueue.Enqueue(newRoad);        
    }

    private float GetRoadPos()
    {
        zPos += zDistance;
        return zPos;
    }
}
