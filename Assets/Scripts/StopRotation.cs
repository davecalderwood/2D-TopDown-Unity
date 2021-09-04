using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotation : MonoBehaviour
{
    Transform t;
    public float fixedRotation = 5;

    void Start () 
    {
        t = transform;
    }
    
    void Update () 
    {
        t.eulerAngles = new Vector3 (t.eulerAngles.x, fixedRotation, t.eulerAngles.z);
    }
}
