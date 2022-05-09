using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null){
            rigid = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);

        if (transform.position.x<screenOrigo.x+1 || transform.position.x>screenBounds.x){
            Destroy(gameObject);
        }
        
    }

    void FixedUpdate()
    { 
        if (isFacingRight)
            rigid.velocity = new Vector2(rigid.velocity.x+1, 0);
        else 
            rigid.velocity = new Vector2(rigid.velocity.x-1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("target")){
            Destroy(gameObject);
        }
    }
}
