using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float distance;
    public float height;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, height, player.position.z - distance);
    }
}
