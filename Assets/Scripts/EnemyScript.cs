using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    [SerializeField]
    PlayerController playerController;
    float step;
    float mSpeed;
    public Transform player;
    void Start () {
        //step = playerController.speed - Random.Range(2f,5f);
    }


    void Update () {
        mSpeed = playerController.speed - Random.Range(4, 9);
        step = mSpeed * Time.deltaTime/4;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
	}
}
