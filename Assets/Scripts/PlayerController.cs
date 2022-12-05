using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public int doubleJump;
    public bool gameOverStatus = false;
    public GameObject gameOverPanel;

    private AudioSource audioJump;
    private Animator playerAnim;
    private int jumpTemp;
    public GameManager gameScore;

    void Start()
    {
        Time.timeScale = 1;
        audioJump = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        jumpTemp = doubleJump;
        playerAnim = GetComponent<Animator>();
    }


    void Update()
    {
        //Jump Control and Jump Animation
        if (Input.GetMouseButtonDown(0) && jumpTemp > 0)
        {
            
            playerRb.velocity = new Vector3(playerRb.velocity.y, jumpForce);
            audioJump.Play();
            isOnGround = false;
            
            playerAnim.SetTrigger("Jump");
            jumpTemp -= 1;
        }
        
        //Check if Player fall off
        if (transform.position.x < -5 || transform.position.y < -5)
        {
            Time.timeScale = 0;
            gameOverStatus = true;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    
    public void StopAnim()
    {
        //Stoping Time and Animation
        Time.timeScale = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Checking If player hits ground and Run Animation
        if (collision.gameObject.CompareTag("Ground"))
        {
            // isOnGround = true;
            playerAnim.SetBool("isRunning", true);
            jumpTemp = doubleJump;
            isOnGround = true;
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }

        //Checking if player hits Obstacle, control player death and animation death
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOverPanel.SetActive(true);
            gameOverStatus = true;
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
            playerAnim.SetBool("isDie", true);
            Invoke("StopAnim", 1f);
        }

        //Check if player hits C
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("collision with coin");
            Destroy(collision.gameObject);
            gameScore.score += 2;
        }

    }
}
