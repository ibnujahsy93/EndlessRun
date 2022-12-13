using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; //mengambil rigidbody player
    public float jumpForce; //menyimpan tinggi rendahnya lompatan player
    public float gravityModifier; //mengatur gravitasi agar lompatan seperti berada diluar angkasa
    public bool isOnGround = true; //menyimpan informasi player menginjak platform
    public int doubleJump; //mengatur lompatan ganda
    public bool gameOverStatus = false; // menyimpan status game over
    public GameObject gameOverPanel; //mengambil objek 

    private AudioSource audioJump; //mengambil audio
    private Animator playerAnim; //mengambil animator
    private int jumpTemp; //menyimpan jumlah lompatan yg telah dilakukan
    public GameManager gameScore; //mengambil game manager

    void Start()
    {
        Time.timeScale = 1; //mengatur jalannya permainan
        audioJump = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; //mengatur agar lompatan melambat saat diudara
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
            gameOverStatus = true;
            gameOverPanel.SetActive(true);
            Invoke("StopAnim", 1f);

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
            gameScore.score += 2; //menambahkan scoree = score + 2
        }

    }
}
