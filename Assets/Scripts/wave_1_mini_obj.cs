using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_1_mini_obj : MonoBehaviour {

    public GameObject player;
    Vector3 player_pos;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform.position);
        player_pos = player.transform.position;
    }

    void Update () {
        transform.position = Vector3.MoveTowards(transform.position,player_pos,0.5f);
    }
}
