using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GoofyScript : MonoBehaviour
{
	public Rigidbody2D myRigidbody;
	public bool birdAlive = true;
    public AppleSpawnerScript appleSpawner;
    public GameObject apple;
    public GameObject apps;
    public GameObject spike;
    public Collider2D colliderEN;

	public ArrowMovement arrowReflection;
	public GameObject arrowMovement;
	public Movement spikeReflection;
	public GameObject spikeMovement;

	/*public GameObject arrowSpawner;
	public GameObject spikeSpawner;*/

    public LogicScript logic1;
	public GameObject logic;
	
    public AudioManager sfx;
	public GameObject sfx1;

	public ParticleSystem jumpParticles;
	public ParticleSystem deathParticles;

	public int movementSpeed = 20;
	// Start is called before the first frame update
	void Start()
	{
		logic1 = logic.GetComponent<LogicScript>();
		appleSpawner = apps.GetComponent<AppleSpawnerScript>();
		sfx = sfx1.GetComponent<AudioManager>();
		/*arrowReflection = arrowMovement.GetComponent<ArrowMovement>();
		spikeReflection = spikeMovement.GetComponent<Movement>();*/


    }

	void Update()
	{
        //reflectGame();
        if (birdAlive)
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				myRigidbody.velocity = Vector2.up * movementSpeed;
				Instantiate(jumpParticles, transform.position, Quaternion.identity);
			}
			if (Input.GetKeyDown(KeyCode.A))
			{
				myRigidbody.velocity = Vector2.left * movementSpeed;
                Instantiate(jumpParticles, transform.position, Quaternion.identity);
            }
			if (Input.GetKeyDown(KeyCode.D))
			{
				myRigidbody.velocity = Vector2.right * movementSpeed;
                Instantiate(jumpParticles, transform.position, Quaternion.identity);
            }
			if (Input.GetKeyDown(KeyCode.S))
			{
				myRigidbody.velocity = Vector2.down * movementSpeed;
                Instantiate(jumpParticles, transform.position, Quaternion.identity);
            }
			if (transform.position.x > 53.9)
			{
				outOfBoundsTeleport(new Vector2(-53.9f, transform.position.y));
			}
			if (transform.position.x < -53.9)
			{
				outOfBoundsTeleport(new Vector2(53.9f, transform.position.y));
			}
			if (transform.position.y > 32.5)
			{
				outOfBoundsTeleport(new Vector2(transform.position.x, -32.5f));
			}
			if (transform.position.y < -32.5)
			{
				outOfBoundsTeleport(new Vector2(transform.position.x, 32.5f));
			}
		}
    }
	/*void increaseMovementSpeed(int movementSpeed)
	{

	}*/
	void outOfBoundsTeleport(Vector2 newPosition)
	{
		transform.position = newPosition;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
            logic1.gameOver();
            birdAlive = false;
			colliderEN.enabled = false;
			sfx.playDeath();
			Instantiate(deathParticles, transform.position, Quaternion.identity);
			GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            Destroy(collision.gameObject);
            logic1.addScore();
			appleSpawner.spawnApple();
			sfx.playAppleSFX();
        }
    }
    
}
