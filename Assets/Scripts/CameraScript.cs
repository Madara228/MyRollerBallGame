using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x - 10, transform.position.y, transform.position.z - 10);
        transform.RotateAround(player.transform.position,transform.right,1f);
    }
}