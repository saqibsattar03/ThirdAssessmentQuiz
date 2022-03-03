using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] bool isOnGround;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    AudioSource jumpSound;
    

    // Start is called before the first frame update
    void Start()
    {
        isOnGround = true;
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        movementSpeed = 10.0f;
        runningSpeed = 7000.0f;
        jumpForce = 4000.0f;
        jumpSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        MoveVertical();
        PlayerJump();
    }

    void MoveHorizontal() 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector3(moveHorizontal,0,0) * movementSpeed;
    }

    void MoveVertical() 
    {
        playerRb.AddForce(Vector3.forward * runningSpeed * Time.deltaTime,ForceMode.Impulse);   
    }

    void PlayerJump() 
    {
        if (isOnGround && Input.GetKey(KeyCode.Space))
        {
            playerRb.velocity = new Vector3(0, 0, playerRb.velocity.z);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            jumpSound.Play();
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("player is on ground");
        }
        else if (collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
            FindObjectOfType<GameManager>().panel.SetActive(true);
            
        }
        else if (collision.gameObject.CompareTag("Animal")) 
        {
            FindObjectOfType<GameManager>().addScore();
        }
    }

}
