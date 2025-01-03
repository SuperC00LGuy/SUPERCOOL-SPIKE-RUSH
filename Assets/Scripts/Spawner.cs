/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject spike;
	public float spawnRate = 5;
	private float timer = 0;
	public float heightOffset = 5;
	public int scalingOffset = 7;

    public LogicScript additionalSpawnerCalc;
    // Start is called before the first frame update
    /*void Start()
    {
        spawnSpike();
        this.additionalSpawnerCalc = FindObjectOfType<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
		if(getPlayerScore() > this.scalingOffset && spawnRate > 1) 
		{
			spawnRate--;
			scalingOffset--;
		}
		if (timer < spawnRate)
		{
			timer = timer + Time.deltaTime; 
		}
		else
		{
			spawnSpike();
			timer = 0; 	
		}
	}
	/*private int getPlayerScore()
	{
		return additionalSpawnerCalc.playerScore;
	}
	void spawnSpike()
	{
		float lowestPoint = transform.position.y - heightOffset;
		float highestPoint = transform.position.y + heightOffset;
		Instantiate(spike, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
	}
     Switching every 5 apples collected
			- Logic gameObject
		Transform position of spawner to the opposite side ()
			- Need spawner gameObject for both spawners
		Inverse spike and arrow vector position 
			- Need arrow and spike gameObjectvoid 
	int switcher = 5;
	int xPos = 69.5;
	Start()
	{	
			if(score % 10 == 0)
			{
				switcher += 10;
			}
			if(score >= switcher)
			{
				xPos = -(xPos);
				reflectGame(inverse x posotion)
			}
			else
			{
				abs(xPos);
				reflectGame(regular x position)
			}
	}
	
	reflectGame(int x-position spawner)
	{
		transform spawner position(according to x-position spawner)
	}
}*/