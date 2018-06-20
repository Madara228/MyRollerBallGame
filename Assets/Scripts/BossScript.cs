using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public GameObject wave_1_mini_objs;
    public int wave_1_speed;


	void Start () {
        wave_1();

	}
	
	void Update () {
		
	}

    void wave_1()
    {
        for(int i = 0; i < 10; i++)
        {
            Instantiate(wave_1_mini_objs,transform.position + new Vector3(i * i, i, i * i), Quaternion.identity);
        }
        StartCoroutine(delete("wave_1_bomb"));

    }

    private IEnumerator delete(string a)
    {
        yield return new WaitForSeconds(4f);
        GameObject[] objs = GameObject.FindGameObjectsWithTag(a);
        for(int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i]);
        }
    }
}
