using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBike : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position += new Vector3(0f, 0f, 0.5f);
    }
}
