using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public bool isOnGround = true;
    public float jumpForce;
    public float gravityModifier;

    public bool gameOver = false;
    
    // Animation Controller
    private Animator playerAnim;

    // Particle Controller
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    // Audio Controller
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound,1.0f);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")&& !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }else if (collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound,0.5f);
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
        }
        
    }
}
