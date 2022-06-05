using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool Move = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            transform.Translate(Vector2.up * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(-Vector2.up * Time.deltaTime, Space.World);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //float force = 150.0f;

        if (collision.gameObject.name == "UpSide")
        {
            Move = false;
        }
        else if (collision.gameObject.name == "DownSide")
        {
            Move = true;
        }
    }
}
