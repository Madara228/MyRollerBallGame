using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingHealers : MonoBehaviour {

    public GameObject heathPref;
    public GameObject speedPref;
    public int k = 0;
    public PlayerController playerController;
	void Start () {
        create(heathPref);
        create(heathPref);
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
                    int a = 0;
                    a = Random.Range(1, 4);
                    if(a == 3)
                    {
                        create(speedPref); 
                    }
                    create(heathPref);
                }
            }
            yield return new WaitForSeconds(5);
        }
    }
    void create(GameObject d)
    {
        Vector3 pos = playerController.center + new Vector3(Random.Range(-playerController.size.x / 2, playerController.size.x / 2), playerController.size.y, Random.Range(-playerController.size.z / 2, playerController.size.z / 2));
        Instantiate(d, pos, transform.rotation);
        k++;
    }
	
	
}
