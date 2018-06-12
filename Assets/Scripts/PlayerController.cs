using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {



//<Vars>
//<Private vars>
    private Rigidbody rb;
    [SerializeField]
    private float speed = 100f;

//</Private vars>

//<Public vars>
    public Vector3 center;
    public Vector3 size;
    public GameObject plane;
    public Button btn;
    public GameObject[] gameObjects;

//</Public vars>

//</Vars>
    void Start () {
        btn = btn.GetComponent<Button>();
		rb = GetComponent<Rigidbody>();
        btn.onClick.AddListener(onClick);
	}
	
	void Update () {
        float x = CrossPlatformInputManager.GetAxis("Horizontal")/**speed*/;
        float y = CrossPlatformInputManager.GetAxis("Vertical")/**speed*/;
        rb.AddForce(new Vector3(x, 0, y)*speed);

        if(x!=0 && y != 0) 
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
	}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 9, 9, 4f);
        Gizmos.DrawCube(center, size);
    }

    void DestrouPlanes()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("TeleportPlane");

        for (int i = 0; i < gameObjects.Length-1; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
    void onClick()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(plane, pos, Quaternion.identity);
        DestrouPlanes();
        
        //for(int i=0; i < gameObjects.Length; i++)
        //{
        //    Destroy(gameObject[i])
        //}
        //print(" ");
    }

}
