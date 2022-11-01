using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float jumpForce;
	public int doubleJump;
	private Rigidbody rb;

	public GameObject gameOver;
	
	private int jumpTemp;
	private AudioSource audioJump;
	private Animator playerAnim;
	public bool gameOverStatus = false;

	// private bool isOnGround =false;

	// Start is called before the first frame update
	void Start()
    {
		playerAnim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		audioJump = GetComponent<AudioSource>();
		jumpTemp = doubleJump;
		gameOver.SetActive(false);
		Time.timeScale = 1;
		

	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpTemp > 0)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			audioJump.Play();
			// isOnGround = false;
			jumpTemp -= 1;

		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			RestartGame();
		}
		
		if(transform.position.y < -5)
		{
			Time.timeScale = 0;
			gameOverStatus = true;
			gameOver.SetActive(true);
		}
    }
	
	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Ground"))
		{
			// isOnGround = true;
			jumpTemp = doubleJump;
		}
		if (other.gameObject.CompareTag("Obstacle"))
		{
			gameOver.SetActive(true);
			gameOverStatus = true;
			playerAnim.SetBool("isDie", true);
			Invoke("StopAnim", 1f);


		}
	}
	public void StopAnim()
    {
		Time.timeScale = 0;
	}

	public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
