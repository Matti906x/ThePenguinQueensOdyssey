using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float runSpeed = 10f;
    [SerializeField] public float jumpSpeed = 10f;
    [SerializeField] float waterJumpSpeed = 10f; // Adjust this for water jump speed
    [SerializeField] float waterMoveSpeed = 0.5f;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] LayerMask waterLayerMask; // Add a layer mask for water
    
    [SerializeField] int score = 100;
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] float volume = 1f;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectileLauncher;
    [SerializeField] AudioClip projectileSFX;
    [SerializeField] float projectileVolume;

    [SerializeField] float deathDelayTime = 2f;
    [SerializeField] AudioClip deathAudio;
    [SerializeField] float deathVolume = 1;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    ScoreKeeper scoreKeeper;
    Shooter shooter;

    bool wasCollected = false;
    bool isAlive = true;
    bool isInWater = false; // Flag to track if the player is in water
    int jumpsLeft = 2000; // Adjust this for number of jumps allowed underwater
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        shooter = GetComponent<Shooter>();
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        Die();

        // Check if the player is in water
        isInWater = myBodyCollider.IsTouchingLayers(waterLayerMask);

        // Check if scoreKeeper is null before trying to update the score
        if (scoreKeeper != null && scoreText != null)
        
        Debug.Log(jumpsLeft);
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        
        // Check if the player is in water and has jumps left
        if (isInWater && jumpsLeft > 0)
        {
            myAnimator.SetBool("isSwimming", true);
            // Perform water jump
            myRigidbody.velocity += new Vector2(0f, waterJumpSpeed);
            jumpsLeft--;
        }
        else if (myBodyCollider.IsTouchingLayers(groundLayerMask))
        {
            myAnimator.SetBool("isSwimming", false);
            // Perform normal jump only if touching ground
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    
    void OnFire(InputValue value)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex == 3)
        {        
            if(!isAlive) { return; }

            if(value.isPressed)
            {
            Instantiate(projectile, projectileLauncher.position, transform.rotation);
            AudioSource.PlayClipAtPoint(projectileSFX, Camera.main.transform.position, projectileVolume);
            }
        }
    }

    void Run()
    {
        float moveSpeed = runSpeed;
        if (isInWater)
        {
            moveSpeed = waterMoveSpeed; // Reduce speed in water
        }

        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        //checks if player is moving
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {            
            isAlive = false;
            myAnimator.SetTrigger("Death");
            AudioSource.PlayClipAtPoint(deathAudio, Camera.main.transform.position, deathVolume);
            
            StartCoroutine(DeathDelay());
        }
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(deathDelayTime);
        FindObjectOfType<UIDisplay>().ProcessPlayerDeath();
    }

    // Add a method to reset jumps when touching ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayerMask)
        {
            jumpsLeft = 1; // Reset jumps when touching ground
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Collectibles" && !wasCollected)
        {
            wasCollected = true;

            // Check if scoreKeeper is null before trying to modify the score
            if (scoreKeeper != null)
            {
                scoreKeeper.ModifyScore(score);
                AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position, volume);
            }

            Destroy(other.gameObject);
            wasCollected = false;
        }
    }
}