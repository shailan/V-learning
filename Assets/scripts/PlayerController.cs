using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
  
    private Rigidbody rb;
    private int count;

    public Text countText;
    public float speed;
    public Text WinText;
    // public Button PlayAgain;
    // public Button Exit;
    public GameObject menu;
    public AudioSource audio;
    private Vector3 spawnpoint;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        WinText.text = "";
        menu.SetActive(false);
        spawnpoint = transform.position;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void FixedUpdate ()
    {
        // for mobile
         //transform.Translate((Input.acceleration.x, 0, -Input.acceleration.z) * Time.deltaTime);
        transform.Translate(new Vector3(Input.acceleration.x, 0, -Input.acceleration.z) * Time.deltaTime * speed);

        if (transform.position.y < .1000f)
        {
            transform.position = spawnpoint;
        }

        //for pc
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3( moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        
    }

    void SetCountText()
    {
        countText.text = "SCORE: " + count.ToString();
        if(count>=120)
        {
            //GetComponent<PlayerController>().speed = 0;
            GetComponent<Rigidbody>().isKinematic = true;
    
            WinText.text = "CONGRATULATIONS! YOU WIN";

            menu.SetActive(true);
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            audio.clip = Resources.Load<AudioClip>("audio/Pick Up");
            audio.Play();

            count = count + 10;
            SetCountText();

        }
    }
}
