using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    [SerializeField]
    PlayerController playerController;
    float step;
    //public bool canTeleport = true;
    float mSpeed;
    [SerializeField]
    public GameObject player;
    void Start () {
        //step = playerController.speed - Random.Range(2f,5f);
        mSpeed = playerController.speed - Random.Range(10, 20);
        StartCoroutine(teleporterEnem());
        player = GameObject.FindGameObjectWithTag("Player");
        //canTeleport = false;
    }


    void Update () {
        //if(Vector3.Distance(transform.position, player.transform.position) < 10f)
        //{
        //    canTeleport = false;
        //}
       // Debug.Log(canTeleport);
        step = mSpeed * Time.deltaTime-3;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
	}

    private IEnumerator teleporterEnem()
    {
        while (true)
        {
            //if (canTeleport == true)
            //{
                yield return new WaitForSeconds(Random.Range(4, 6));
                transform.position = playerController.center + new Vector3(Random.Range(-playerController.size.x / 2, playerController.size.x / 2), playerController.size.y, Random.Range(-playerController.size.z / 2, playerController.size.z / 2));
            //}
        }
    }
    
    //IEnumerator checkIt()
    //{
    //    if (Vector3.Distance(transform.position, player.transform.position) < 100 0f)
    //    {
    //        canTeleport = false;
    //    }
    //    yield return new WaitForSeconds(2f);
    //}
}
