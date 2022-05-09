using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoMovement : MonoBehaviour
{
    //[SerializeField] ConstantForce2D cForce;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float forceY;
    [SerializeField] float forceX;
    [SerializeField] bool upDown = false;
    [SerializeField] bool leftRight = false;
    [SerializeField] GameObject controller;
    [SerializeField] AudioSource audio;
    // [SerializeField] int defaultSize = 4;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null){
            rigid = GetComponent<Rigidbody2D>();
        }
        if (controller==null){
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        if (audio==null){
            audio = GetComponent<AudioSource>();
        }
        forceY = Random.Range(1,2f);
        forceX = Random.Range(1,2f);
        InvokeRepeating("changeScale", 0.5f*(SceneManager.GetActiveScene().buildIndex+1), 0.5f*(SceneManager.GetActiveScene().buildIndex+1));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);

        if (transform.position.y < screenOrigo.y+3 || transform.position.y>(screenBounds.y/2)){
            upDown = true;
        } 
        if (transform.position.x<screenOrigo.x+1 || transform.position.x>screenBounds.x){
            leftRight = true;
        }
    }

    void FixedUpdate()
    { 
        if (upDown && leftRight){
            forceY = -forceY;
            forceX = -forceX;
            leftRight = false;
            upDown = false;
        } else if (leftRight){
            forceX = -forceX;
            //forceY = 0;
            leftRight = false;
        } else if (upDown){
            //forceX = 0;
            forceY = -forceY;
            upDown = false;
        } 
        rigid.velocity = new Vector2(forceX, forceY);
    }

    private void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.CompareTag ("pin"))
        {
            AudioSource.PlayClipAtPoint(audio.clip,transform.position);
            int score = (int)Mathf.Abs(gameObject.transform.localScale.x-10);
            controller.GetComponent<Scorekeeper>().UpdateScore(score);
            Destroy(gameObject);
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void changeScale()
    {
        gameObject.transform.localScale += new Vector3(0.3f,0.3f,0);
        if (gameObject.transform.localScale.x >= 7.5f){
            // AudioSource.PlayClipAtPoint(audio.clip,transform.position);
            Destroy(gameObject);
            CancelInvoke("changeScale");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
