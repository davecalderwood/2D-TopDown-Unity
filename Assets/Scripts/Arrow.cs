using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    void Update()
    {
        Object.Destroy(gameObject, 2.0f);
    }
}
