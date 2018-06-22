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
            StartCoroutine(adder());
            Destroy(this.gameObject);
            Debug.Log("work!");
        }
    }

    private IEnumerator adder()
    {
        playerController.adder *=2;
        yield return new WaitForSeconds(10f);
        playerController.adder = 1;
        print("hey");
    }
}
