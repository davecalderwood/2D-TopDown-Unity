using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        // transform.Translate(transform.up * speed * Time.deltaTime);

        Object.Destroy(gameObject, 2.0f);
    }
}
