using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

class PoolObject
{
    public Transform transform;
    public bool isInUse;

    public PoolObject(Transform t)
    {
        transform = t;
    }

    public void SetUse()
    {
        isInUse = true;
    }

    public void SetUnUse()
    {
        isInUse = false;
    }
}
