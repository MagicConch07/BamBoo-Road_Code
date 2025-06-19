using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawntongnamu : MonoBehaviour
{
    public GameObject[] Tongnamu;
    void Start()
    {
        SpawnTreed();
    }

    void SpawnTreed()
    {
        StartCoroutine("SpawnTree");
    }

    IEnumerator SpawnTree()
    {
        while (true)
        {
            Instantiate(Tongnamu[Random.Range(0, 4)], transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            yield return new WaitForSeconds(Random.Range(8, 12));
        }
    }
}