using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private float speed = 6;
    private float leftBound = -15;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOverStatus == false)
        {
            if (gameObject.tag == "Obstacle")
            {
                transform.Translate(Vector3.left * Time.deltaTime * -speed);
                if (transform.position.x < leftBound)
                {
                    Destroy(gameObject);
                }
            }
            if (gameObject.tag == "Coin")
            {
                transform.Translate(Vector3.left * Time.deltaTime * -speed);
                if (transform.position.x < leftBound)
                {
                    Destroy(gameObject);
                }
            }
            if (gameObject.tag == "Background")
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);

            }
            if (gameObject.tag == "Ground")
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                if (transform.position.x < leftBound)
                {
                    Destroy(gameObject);
                }
            }
        }
        

    }
}
