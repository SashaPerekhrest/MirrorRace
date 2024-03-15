using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject coin;
    public GameObject car;
    public GameObject bike;
    public GameManager manager;
    public GameObject house;

    private void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(SpawnHouse());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.7f);
        for (; ; )
        {
            if (manager.GameActive)
            {
                var toSpawn = new GameObject();
                var randPos = Random.Range(1, 4);
                var randObj = Random.Range(1, 4);
                switch (randObj)
                {
                    case 1:
                        toSpawn = coin;
                        break;
                    case 2:
                        toSpawn = car;
                        break;
                    case 3:
                        toSpawn = bike;
                        break;
                }
                switch (randPos)
                {
                    case 1:
                        Instantiate(toSpawn, new Vector3(0, 1, transform.position.z), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(toSpawn, new Vector3(2.5f, 1, transform.position.z), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(toSpawn, new Vector3(-2.5f, 1, transform.position.z), Quaternion.identity);
                        break;
                }
            }
            yield return new WaitForSeconds(0.7f);
        }
    }

    IEnumerator SpawnHouse()
    {
        for (; ; )
        {
            if (manager.GameActive)
            {
                var toSpawn = house;
                var randPos = Random.Range(1, 3);
                switch (randPos)
                {
                    case 1:
                        Instantiate(toSpawn, new Vector3(13 + Random.Range(0, 10), -Random.Range(1, 40), transform.position.z + 360), Quaternion.Euler(0, 30 + Random.Range(-15,15) ,0));
                        break;
                    case 2:
                        Instantiate(toSpawn, new Vector3(-13 - Random.Range(0, 10), -Random.Range(1, 40), transform.position.z + 360), Quaternion.Euler(0, 30 + Random.Range(-20, 40), 0));
                        break;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
