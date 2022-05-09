using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballonSpwaner : MonoBehaviour
{
    [SerializeField] GameObject ballon;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 position = new Vector2(Random.Range(-9,17f),Random.Range(-2,5f));
        Instantiate(ballon, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
