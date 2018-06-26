using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

    public PlayerController playerController;

    void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("work!");
            StartCoroutine(adder_speed());
        }
    }

    IEnumerator adder_speed()
    {
        playerController.adder += 0.5f;
        yield return new WaitForSeconds(5f);
       // playerController.adder = 1;
        Debug.Log("hey");
    }
}
