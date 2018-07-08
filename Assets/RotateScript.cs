using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {
    public GameObject player;
	void Update () {
        transform.RotateAround(player.transform.position, new Vector3(0,10,0), 100 * Time.deltaTime*10f);
	}
}
