using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    float xFactor, yFactor;
    private GameObject boss;

    //</Private vars>

    //<Public vars>
    public float health = 10f;
    public Text healthText;
    public float speed = 70F;
    public CreatingHealers creatingHealers;
    public Vector3 center;
    public GameObject boss_obj;
    public Text losharaText;
    public Vector3 size;
    public bool canStopped = true;
    public Button btn_teleport;
    public float adder = 1;
    public bool isCreated = false;
    public VirtualJoystick virtualJoystick;
    public Button new_adder; 
//</Public vars>

//</Vars>
    void Start () {
        boss = GameObject.FindGameObjectWithTag("Boss");
        remakeText();
		rb = GetComponent<Rigidbody>();
        new_adder = new_adder.GetComponent<Button>();
        btn_teleport = btn_teleport.GetComponent<Button>();
        new_adder.onClick.AddListener(addForcing);
        btn_teleport.onClick.AddListener(TeleportPlayer);
        print(boss);
    }
	
	void Update () {
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();
        rb.AddForce(new Vector3(x, 0, y) * (speed * 1.5f) * adder);
        if (x != 0 && y != 0)
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


    void TeleportPlayer()
   {
        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
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
            health += Random.Range(1f,2f);
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
        if (health >=20f && isCreated == false && boss == null)
        {
            StartCoroutine(youNotLoshara());
            isCreated = true;
        }
        
    }

    private IEnumerator loshara()
    {
        losharaText.text = "Лошара!";
        yield return new WaitForSeconds(5);

        //if (yFactor == 1920 && xFactor == 1080 || yFactor == 1080 && xFactor == 1920)
        //{
        //    SceneManager.LoadScene("MainScene");
        //}
        //else if (yFactor == 1280 && xFactor == 720 || yFactor == 720 && xFactor == 1280)
        //{
        //    SceneManager.LoadScene("MainScene_720p");
        //}
        //else if (yFactor == 2960 && xFactor == 1440 || yFactor == 1440 && xFactor == 2960)
        //{
        //    SceneManager.LoadScene("MainScene_2940");
        //}
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainScene");
    }
    private IEnumerator youNotLoshara()
    {
        losharaText.text = "Time to fight with boss, loshara!";
        yield return new WaitForSeconds(3);
        createBoss();
        isCreated = true;
        losharaText.text = "";
    }
    void createBoss()
    { 
        SceneManager.LoadScene("BossScene");

    }

    void addForcing()
    {
        rb.AddForce(transform.forward * speed * speed*adder*2);
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
