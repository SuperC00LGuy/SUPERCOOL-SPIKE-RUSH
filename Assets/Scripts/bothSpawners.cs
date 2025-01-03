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
    private int switcher = 5;
    private float xPos = 69.5f;
    private float yPos = -1.9f;
    private bool changeMovement = false;

    void Start()// Start is called before the first frame update
    {
        spawnSpike();
        spawnArrow();
        this.additionalSpawnerCalc = FindObjectOfType<LogicScript>();
    }

    void Update() // Update is called once per frame
    {
        //Spiker Spawner "Function"
        if (spikeTimer < spikeSpawnRate)
        {
            spikeTimer = spikeTimer + Time.deltaTime;
        }
        else
        {
            spawnSpike();
            spikeTimer = 0;
        }

        //Arrow Spawner "Function"
        if(arrowTimer < arrowSpawnRate)
        {
            arrowTimer = arrowTimer + Time.deltaTime;
        }
        else
        {
            spawnArrow();
            arrowTimer = 0;
        }
        //Reflection "Function"
        if (getPlayerScore() < switcher)
        {
            xPos = Mathf.Abs(xPos);
            reflectSpawner(xPos);
            changeMovement = false;
        }
        else
        {
            xPos = -(xPos);
            reflectSpawner(xPos);
            changeMovement = true;
        }
        if (getPlayerScore() % 10 == 0) //Update calls this a bigillion making switcher a large number
        {
            switcher += 10;
        }
        /* Check 
         * invokeTime = 65;
           decreaseTime = -5;
        - ON EVERY INVOKE HIT WE DECREASE INVOKETIME BY 5 UNTIL WE REACH 30 
        - WOULD HAVE TO CREATE A FUNCTION FOR 
         * InvokeReapting(nameOf(switchReflection), invokeTime, decreaseTime)
             * if(invokeTime != 30 && decrease != 0)
                {
                  invokeTime -= decreaseTime             
                }
                else
                {
                    decreaseTime == 0;
                }

            void switchReflection(int& xPosition)
            {
                if(changeMovement)
                {
                    relfectSpawner(xPosition);
                    xPosition = Mathf.Abs(xPosition);  
                    changeMovement = false;
                }
                else
                {
                    reflectSpawner(xPosition);
                    xPosition = -(xPosition);
                    changemovement = true;
                }
            {
         */
        checkArrow();
        checkSpike();  
    }
    private int getPlayerScore()
    {
        return additionalSpawnerCalc.playerScore;
    }
    void spawnArrow() //Spawns arrow
    {
        float lowestPoint = transform.position.y - arrowHeightOffset;
        float highestPoint = transform.position.y + arrowHeightOffset;
        Instantiate(arrow, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
    void spawnSpike() //Spawns spike
    {
        float lowestPoint = transform.position.y - spikeHeightOffset;
        float highestPoint = transform.position.y + spikeHeightOffset;
        Instantiate(spike, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
    void checkArrow() //Checking to see if the player score is high enough to scale up for arrow
    {
        if (this.getPlayerScore() > this.scalingOffset && arrowSpawnRate > 0.6) //arrow
        {
            arrowSpawnRate = arrowSpawnRate - 0.2f;
        }
    }
    void checkSpike() //Checking to see if the player score is high enough to scale up for spike
    {
        if (getPlayerScore() > this.scalingOffset && spikeSpawnRate > 0.4) //spike
        {
            spikeSpawnRate = arrowSpawnRate -0.2f;
            scalingOffset -= 1;

        }
    }
    void reflectSpawner(float xPos)
    {
        Vector3 newXPos = new Vector3(this.xPos, yPos, 0);
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
