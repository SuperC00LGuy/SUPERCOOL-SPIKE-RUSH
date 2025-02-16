using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class bothSpawners : MonoBehaviour
{
    [Header("========== Game Objects ===========")]
    public GameObject spike;
    public GameObject arrow;
    public LogicScript additionalSpawnerCalc;

    [Header("========== Spawn Rate ===========")]
    public float spikeSpawnRate = 0.8f;
    public float arrowSpawnRate = 1;

    [Header("========== Height Offsets ===========")]
    public float spikeHeightOffset = 25;
    public float arrowHeightOffset = 15;

    [Header("========== Additional things ===========")]
    public int scalingOffset = 7;
    private float spikeTimer = 0.0f;
    private float arrowTimer = 0.0f;

    //Reverse variables
    private float xPos = 69.5f;
    private float yPos = -1.9f;
    public bool changeMovement = true;
        //Invoke
    public float decreaseTime = -5f;
    public float reflectRate = 40.0f;
    private float reflectTimer = 0.0f;

    void Start()// Start is called before the first frame update
    {
        this.additionalSpawnerCalc = FindObjectOfType<LogicScript>();
        //NOT CALLING CORRECTLY PIECE OF SHIT
        //InvokeRepeating(nameof(switchReflection), 0, invokeTime); //Starting in 60 seconds every 60 seconds switchReflection gets called
        //CancelInvoke(nameof(switchReflection));
    }

    void Update() // Update is called once per frame
    {
        arrowSpawner();
        spikeSpawner();
        reflectionTimer();
        checkArrow();
        checkSpike();  
    }
    public void reflectionTimer()
    {
        if (reflectTimer < reflectRate)
        {
            reflectTimer = reflectTimer + Time.deltaTime;
        }
        else
        {
            xPos = switchReflection(xPos);
            checkReflectRate();
            reflectTimer = 0;
        }
    }
    public float switchReflection(float xPosition)
    {
        if(changeMovement)
        {
            xPosition = Mathf.Abs(xPosition);
            reflectSpawner(xPosition);
            changeMovement = false;
            Debug.Log("changeMovmement is false");
        }
        else
        {
            xPosition = -(xPosition);
            reflectSpawner(xPosition);
            changeMovement = true;
            Debug.Log("changeMovement is true");
        }
        return xPosition;
    }
    private int getPlayerScore()
    {
        return additionalSpawnerCalc.playerScore;
    }
    public void spawnArrow() //Spawns arrow
    {
        float lowestPoint = transform.position.y - arrowHeightOffset;
        float highestPoint = transform.position.y + arrowHeightOffset;
        Instantiate(arrow, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
    public void spawnSpike() //Spawns spike
    {
        float lowestPoint = transform.position.y - spikeHeightOffset;
        float highestPoint = transform.position.y + spikeHeightOffset;
        Instantiate(spike, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
    public void checkArrow() //Checking to see if the player score is high enough to scale up for arrow
    {
        if (this.getPlayerScore() > this.scalingOffset && arrowSpawnRate > 0.6) //arrow
        {
            arrowSpawnRate = arrowSpawnRate - 0.1f;
        }
    }
    public void checkSpike() //Checking to see if the player score is high enough to scale up for spike
    {
        if (getPlayerScore() > this.scalingOffset && spikeSpawnRate > 0.4) //spike
        {
            spikeSpawnRate = arrowSpawnRate -0.1f;
            scalingOffset -= 1;

        }
    }
    public void checkReflectRate()
    {
        if (reflectRate != 30 && decreaseTime != 0)
        {
            reflectRate += decreaseTime;
        }
        else
        {
            decreaseTime = 0;
        }
    }
    public void arrowSpawner()
    {
        if (arrowTimer < arrowSpawnRate)
        {
            arrowTimer = arrowTimer + Time.deltaTime;
        }
        else
        {
            spawnArrow();
            arrowTimer = 0;
        }
    }
    public void spikeSpawner()
    {
        if (spikeTimer < spikeSpawnRate)
        {
            spikeTimer = spikeTimer + Time.deltaTime;
        }
        else
        {
            spawnSpike();
            spikeTimer = 0;
        }
    }
    void reflectSpawner(float xPos)
    {
        transform.position = new Vector3(xPos, yPos, 0);
        Debug.Log(xPos);
    }
    public bool changeDirection()
    {
        return changeMovement;
    }
    /*
     * Switching every 5 apples collected
			- Logic gameObject
		Transform position of spawner to the opposite side ()
			- Need spawner gameObject for both spawners
		Inverse spike and arrow vector position 
			- Need arrow and spike gameObjectvoid */
}
