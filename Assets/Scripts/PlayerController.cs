using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {



//<Vars>
//<Private vars>
    private Rigidbody rb;
    private float rotation;
    [SerializeField]
    private GameObject[] gameObjects;
    Vector3 pos;
    //</Private vars>

    //<Public vars>
    public float health = 10f;
    public Text healthText;
    public float speed = 20F;
    public CreatingHealers creatingHealers;
    public Vector3 center;
    public GameObject boss_obj;
    public Text losharaText;
    public Vector3 size;
    public GameObject plane;
    public Button btn;
    public bool canStopped = true;
    public Button btn_teleport;
    public float adder = 1;
    public bool isCreated = false;

//</Public vars>

//</Vars>
    void Start () {
        remakeText();
        btn = btn.GetComponent<Button>();
		rb = GetComponent<Rigidbody>();
        btn.onClick.AddListener(onClick);
        btn_teleport = btn_teleport.GetComponent<Button>();
        btn_teleport.onClick.AddListener(TeleportPlayer);
	}
	
	void Update () {
        float x = CrossPlatformInputManager.GetAxis("Horizontal") * speed*adder ;
        float y = CrossPlatformInputManager.GetAxis("Vertical") * speed*adder;
       // rotation = x*1f*Time.deltaTime;
        rb.AddForce(new Vector3(x, 0, y));
        //transform.rotation = Quaternion.identity;
        if(x!=0 && y != 0) 
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
	}

    void FixedUpdate()
    {
       // transform.Rotate(0f, rotation, 0f);
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
        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(plane, pos, Quaternion.identity);
        DestrouPlanes();
        
        //for(int i=0; i < gameObjects.Length; i++)
        //{
        //    Destroy(gameObject[i])
        //}
        //print(" ");
    }

    void TeleportPlayer()
    {
        transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy"){
            health -= 1f;
            remakeText();
            collision.transform.position = new Vector3(collision.transform.position.x-10f, collision.transform.position.y, collision.transform.position.z - 10f);
            int a = 0;
            a = Random.Range(1, 5);
            if (a == 1 && canStopped == true)
            {
                StartCoroutine(korni());
            }
        }
        
        
        if (collision.gameObject.tag == "wave_2_bomb")
        {
            health -= 5;
            Destroy(collision.gameObject);
            remakeText();

        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Health")
        {
            health += Random.Range(1f,4f);
            creatingHealers.k -= 1;
            Destroy(other.gameObject);
            remakeText();
           
        }
        if (other.gameObject.tag == "wave_1_bomb")
        {
            health -= 0.5f;
            Destroy(other);
            remakeText();
        }
    }

    public void remakeText()
    {
        healthText.text = health.ToString();    
        if (health < 1f)
        {
            StartCoroutine(loshara());
        }
        if (health >=20f && isCreated == false)
        {
            StartCoroutine(youNotLoshara());
            isCreated = true;
        }
    }

    private IEnumerator loshara()
    {
        losharaText.text = "Лошара!";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private IEnumerator youNotLoshara()
    {
        losharaText.text = "Time to fight with boss, loshara!";
        yield return new WaitForSeconds(3);
        createBoss();
        losharaText.text = "";
    }
    void createBoss()
    {

        SceneManager.LoadScene("BossScene");

        //GameObject[] gameObjects_enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //for(int i =0; i<gameObjects_enemy.Length; i++)
        //{
        //    Destroy(gameObjects_enemy[i]);
        //}
        //Vector3 pos = new Vector3(-8, 10, 13);
        //Instantiate(boss_obj, pos, Quaternion.identity);
    }


    private IEnumerator korni()
    {
        float k = 0;
        k = speed;
        canStopped = false;
        speed = 0;
        yield return new WaitForSeconds(3f);
        speed = k;
        canStopped = true;
        Debug.Log(canStopped);
    }
}
