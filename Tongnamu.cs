using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongnamu : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ender"))
        {
            Destroy(gameObject);
        }
    }
}