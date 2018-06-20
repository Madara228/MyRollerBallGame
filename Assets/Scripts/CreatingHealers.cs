using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingHealers : MonoBehaviour {

    public GameObject heathPref;
    public int k = 0;
    public PlayerController playerController;
	void Start () {
        create();
        create();
        StartCoroutine(instantiatorPrefs());
	}

    private IEnumerator instantiatorPrefs()
    {
        while (true)
        {
            if (k < 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    create();
                }
            }
            yield return new WaitForSeconds(5);
        }
    }
    void create()
    {
        Vector3 pos = playerController.center + new Vector3(Random.Range(-playerController.size.x / 2, playerController.size.x / 2), playerController.size.y, Random.Range(-playerController.size.z / 2, playerController.size.z / 2));
        Instantiate(heathPref, pos, transform.rotation);
        k++;
    }
	
	
}
