using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_1_mini_obj : MonoBehaviour {

    public GameObject player;
    Vector3 player_pos;
    private Rigidbody myRb;
    private float speed = 120f;
	void Start () {
        myRb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform.position);
        //player_pos = player.transform.position;
    }

    void Update () {
        myRb.velocity = transform.forward * speed;
    }
}
