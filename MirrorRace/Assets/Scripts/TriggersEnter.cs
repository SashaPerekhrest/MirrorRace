using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TriggersEnter : MonoBehaviour
{
    public GameObject Road;
    public Text scoreT;
    public GameManager manager;

    private int score;

    private void Awake()
    {
        score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Road" && this.gameObject.tag == "Player")
            Instantiate(Road, other.transform.position + new Vector3(0,0,360), Quaternion.identity);
        if (other.tag == "Coin")
        {
            score++;
            Destroy(other.gameObject);
            scoreT.text = score.ToString();
            manager.score = score;
            Debug.Log("coin");
        }
        if (other.tag == "Car")
        {
            var destroy = GetComponentsInChildren<MeshDestroy>();
            foreach(var m in destroy)
                m.DestroyMesh();
            manager.GameActive = false;
        }
    }
}
