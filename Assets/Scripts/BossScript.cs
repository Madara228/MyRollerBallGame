using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public GameObject wave_1_mini_objs;
    public GameObject wave_2_bombs;
    GameObject player;
    public int boss_health = 40;
    private Rigidbody rb;
    PlayerController playerController;

	void Start () {
        rb = GetComponent<Rigidbody>();
        // playerController = player.GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        kickPlayer();

        //StartCoroutine(usingSkills());
        //wave_1();
      //  kickPlayer();
	}
	
	void Update () {
        //kickPlayer();

    }

    void wave_1()
    {
        for(int i = 0; i < 10; i++)
        {
            Instantiate(wave_1_mini_objs,transform.position + new Vector3(i * i*i, transform.position.y, i * i), Quaternion.identity);
        }
        StartCoroutine(delete("wave_1_bomb"));
        //StartCoroutine(wave_2());

    }



    private IEnumerator wave_2()
    {
        for (int i = 0; i < 60; i++)
        {
            Vector3 pos = playerController.center + new Vector3(Random.Range(-playerController.size.x / 2, playerController.size.x / 2),
                90, Random.Range(-playerController.size.z / 2, playerController.size.z / 2));
            Instantiate(wave_2_bombs, pos,Quaternion.identity);
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine(delete("wave_2_bomb"));

    }



    private IEnumerator delete(string a)
    {
        yield return new WaitForSeconds(6f);
        GameObject[] objs = GameObject.FindGameObjectsWithTag(a);
        for (int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i]);
        }
    }


    private IEnumerator usingSkills()
    {
        int a = 0;
        while (true)
        {
                yield return new WaitForSeconds(5f);

            a = Random.Range(1, 4);
            if (a == 1)
            {
                wave_1();
            }
            if(a==2)
            {
                StartCoroutine(wave_2());
            }
            else
            {
                
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player") {
            playerController.health -= 1;
            playerController.remakeText();
            boss_health -= 5;
           // Teleport();
        }
    }



    //void Teleport()
    //{
    //    Vector3 pos = playerController.center + new Vector3(Random.Range(-playerController.size.x / 2, playerController.size.x / 2),
    //           playerController.size.y, Random.Range(-playerController.size.z / 2, playerController.size.z / 2));
    //    transform.position = pos;
    //}

    void kickPlayer()
    {
        while(Vector3.Distance(player.transform.position, transform.position) > 10f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.00001f);
        }
    }


    //private IEnumerator third_skill()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //}
}
