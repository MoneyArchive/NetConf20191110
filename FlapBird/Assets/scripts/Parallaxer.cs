using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Parallaxer : MonoBehaviour
{
    public GameObject Prefab;
    public int PoolSize;
    public float ShiftSpeed;
    public float SpawnRate;
    public Vector3 DefaultSpawnPos;
    public bool IsSpawnImmediate;
    // particle prewarm
    public Vector3 ImmediateSpawnPos;
    // fit screen ratio
    public Vector2 TargetAspectRatio;
    public YSpawnRange YSpawnRange;

    private float spawnTimer;
    private float targetAspect;
    private PoolObject[] poolObjects;
    private GameManager game;

    void Awake()
    {
        Configure();
    }

    void Start()
    {
        game = GameManager.Instance;
    }

    void OnEnable()
    {
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
    }

    void OnDisable()
    {
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
    }

    void OnGameOverConfirmed()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            poolObjects[i].SetUnUse();
            poolObjects[i].transform.position = Vector3.one * 1000;
        }
        Configure();
    }

    void Update()
    {
        if (game.GameOver) return;

        Shift();
        spawnTimer += Time.deltaTime;
        if (spawnTimer > SpawnRate)
        {
            Spawn();
            spawnTimer = 0;
        }
    }

    void Configure()
    {
        //spawning pool objects
        targetAspect = TargetAspectRatio.x / TargetAspectRatio.y;
        poolObjects = new PoolObject[PoolSize];
        for (int i = 0; i < poolObjects.Length; i++)
        {
            GameObject go = Instantiate(Prefab) as GameObject;
            Transform t = go.transform;
            t.SetParent(transform);
            t.position = Vector3.one * 1000;
            poolObjects[i] = new PoolObject(t);
        }

        if (IsSpawnImmediate)
        {
            SpawnImmediate();
        }
    }

    void Spawn()
    {
        //moving pool objects into place
        Transform t = GetPoolObject();
        if (t == null) return;
        Vector3 pos = Vector3.zero;
        pos.y = Random.Range(YSpawnRange.MinY, YSpawnRange.MaxY);
        pos.x = (DefaultSpawnPos.x * Camera.main.aspect) / targetAspect;
        t.position = pos;
    }

    void SpawnImmediate()
    {
        Transform t = GetPoolObject();
        if (t == null) return;
        Vector3 pos = Vector3.zero;
        pos.y = Random.Range(YSpawnRange.MinY, YSpawnRange.MaxY);
        pos.x = (ImmediateSpawnPos.x * Camera.main.aspect) / targetAspect;
        t.position = pos;
        Spawn();
    }

    void Shift()
    {
        //loop through pool objects 
        //moving them
        //discarding them as they go off screen
        for (int i = 0; i < poolObjects.Length; i++)
        {
            poolObjects[i].transform.position += Vector3.right * ShiftSpeed * Time.deltaTime;
            CheckDisposeObject(poolObjects[i]);
        }
    }

    void CheckDisposeObject(PoolObject poolObject)
    {
        //place objects off screen
        if (poolObject.transform.position.x < (-DefaultSpawnPos.x * Camera.main.aspect) / targetAspect)
        {
            poolObject.SetUnUse();
            poolObject.transform.position = Vector3.one * 1000;
        }
    }

    Transform GetPoolObject()
    {
        //retrieving first available pool object
        for (int i = 0; i < poolObjects.Length; i++)
        {
            if (!poolObjects[i].IsInUse)
            {
                poolObjects[i].SetUse();
                return poolObjects[i].transform;
            }
        }
        return null;
    }
}

class PoolObject
{
    public Transform transform;
    public bool IsInUse;

    public PoolObject(Transform t)
    {
        transform = t;
    }

    public void SetUse()
    {
        IsInUse = true;
    }

    public void SetUnUse()
    {
        IsInUse = false;
    }
}

[Serializable]
public struct YSpawnRange
{
    public float MinY;
    public float MaxY;
}