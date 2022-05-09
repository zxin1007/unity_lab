using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{

    [SerializeField] GameObject pin;
    [SerializeField] Rigidbody2D Player;
    [SerializeField] float x;
    [SerializeField] float y;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&&!Input.GetKey(KeyCode.Mouse0)){
            Spwan();
        }

    }

    void Spwan (){
        x = Player.transform.position.x;
        y = Player.transform.position.y + 1;
        Vector2 position = new Vector2(x,y);
        Instantiate(pin, position, Quaternion.identity);
    }
}
