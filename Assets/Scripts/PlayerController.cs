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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        audioJump = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        jumpTemp = doubleJump;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && jumpTemp > 0)
        {
            
            playerRb.velocity = new Vector3(playerRb.velocity.y, jumpForce);
            audioJump.Play();
            isOnGround = false;
            
            playerAnim.SetTrigger("Jump");
            jumpTemp -= 1;
        }
        

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
        Time.timeScale = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
       
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

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOverPanel.SetActive(true);
            gameOverStatus = true;
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
            playerAnim.SetBool("isDie", true);
            Invoke("StopAnim", 1f);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("collision with coin");
            Destroy(collision.gameObject);
            gameScore.score += 2;
            

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
