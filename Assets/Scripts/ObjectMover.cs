using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    
    private float speed = 6; //mengatur kecepatan objek rintangan
    private float leftBound = -15; //mengatur batas jarak objek yang akan didestroy
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); 

    }

    // Update is called once per frame
    void Update()
    {
        //Moving All Object except Player to move left
        if (playerControllerScript.gameOverStatus == false)
        {
            if (gameObject.tag == "Obstacle") //mengatur objek yang bergerak hanya pada objek dengan tag obstacle
            {
                transform.Translate(Vector3.left * Time.deltaTime * -speed);
                if (transform.position.x < leftBound)
                {
                    Destroy(gameObject);
                }
            }
            if (gameObject.tag == "Coin") //mengatur objek yang bergerak hanya pada objek dengan tag coin
            {
                transform.Translate(Vector3.left * Time.deltaTime * -speed);
                if (transform.position.x < leftBound)
                {
                    Destroy(gameObject);
                }
            }
            if (gameObject.tag == "Background") //mengatur objek yang bergerak hanya pada objek dengan tag background
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);

            }
            if (gameObject.tag == "Ground") //mengatur objek yang bergerak hanya pada objek dengan tag ground
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
