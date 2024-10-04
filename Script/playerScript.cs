using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class playerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isNen;
    private Animator anim;
    public ParticleSystem psBui;
    public GameObject menu, menu2, menuWin;
    private bool isPlaying = true;
    private int countCoin = 0;
    public TMP_Text txtCoin;
    public AudioSource soundCoin;
    private bool isRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 scale = transform.localScale;
        anim.SetBool("isRunning", false);
        Quaternion rotation = psBui.transform.localRotation;

        //khi nguoi dung nhan nut ben phai
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            rotation.y = 180;
            psBui.transform.localRotation = rotation;
            psBui.Play();
            anim.SetBool("isRunning", true);
            scale.x = 1;
            //vecto3(1,0,0)
            transform.Translate(Vector3.right * 3f * Time.deltaTime);
        }
        //nhan ben trai
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;
            rotation.y = 0;
            psBui.transform.localRotation = rotation;
            psBui.Play();
            anim.SetBool("isRunning", true) ;
            scale.x = -1;
            transform.Translate(Vector3.left * 3f * Time.deltaTime);
        }
        transform.localScale = scale;
        //nhan space
        if (Input.GetKey(KeyCode.Space))
        {
            if (isNen)
            {
                rb.AddForce(new Vector2(0, 400));
                //transform.Translate(Vector3.up * 10f * Time.deltaTime);
                isNen = false;
            }
           
        }

        //GetKey: nhan giu nut
        //GetKeyDown:nhan phim 1 lan
        //GetKeyUp: nhan giu roi moi chay

        //pause game va show menu
        if(Input.GetKeyDown(KeyCode.P))
        {
            showMenu();
        }

        //ban dan
        if (Input.GetKeyDown(KeyCode.B))
        {
            var x = transform.position.x + (isRight ? 0.5f : -0.5f);
            var y = transform.position.y;
            var z = transform.position.z;
            GameObject gameObject  = (GameObject) Instantiate(
                Resources.Load("Prefabs/bullet"),
                new Vector3(x,y,z),
                Quaternion.identity
                );
            gameObject.GetComponent<BulletScript>().setIsRight(isRight);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "nen")
        {
            isNen = true;
        }
        if (collision.gameObject.tag == "gate")
        {
            SceneManager.LoadScene("Man02");
        }
        if(collision.gameObject.tag == "end")
        {
            Time.timeScale = 0;
            menuWin.SetActive(true);
        }
    }
    //an coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            soundCoin.Play();
            countCoin += 1;
            txtCoin.text = countCoin + " x";
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "trai")
        {
            //game over, replay
            Time.timeScale = 0;// dung 
            menu2.SetActive(true);
            
        }
        
    }

    public void showMenu()
    {
        if (isPlaying)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            isPlaying = false;
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            isPlaying = true;
        }
    }
    
}
