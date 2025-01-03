using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float moveSpeed = 40;
    public float leftDeadzone = -70;
    public float rightDeadzone = 70;
    public int reflection;
    public float movementSpeedRange;

    public LogicScript additionalSpikeCalc;
    public bothSpawners changer;
    public int playerScoreMulti;

    //public GameObject logic;
    // Start is called before the first frame update
    void Start()
    {
        this.additionalSpikeCalc = FindObjectOfType<LogicScript>();
        this.changer = FindObjectOfType<bothSpawners>();
        if(additionalSpikeCalc == null)
        {
            Debug.Log("ERROR ERROR ERROR ERROR");
        }
        if (changer == null)
        {
            Debug.Log(" Changer ERROR ERROR ERROR ERROR");
        }
        if (changer.changeDirection())
        {
            Debug.Log(" Changer TRUE ERROR ERROR ERROR " + getPlayerScore());
        }
        if (!changer.changeDirection())
        {
            Debug.Log(" Changer TRUE ERROR ERROR ERROR " + getPlayerScore());
        }
    }

    // Update is called once per frame
    void Update()
    {
        spikeMovementReflection(reflection, getPlayerScore());
	}
    private int getPlayerScore()
    {
        return additionalSpikeCalc.playerScore;   
    }
    void spikeMovementReflection(int reflection, int playerScoreMulti)
    {
        movementSpeedRange = Random.Range(1f, 2f);
        /*transform.position = transform.position + (Vector3.left * ((moveSpeed + (float)playerScoreMulti) * movementSpeedRange)) * Time.deltaTime;
        if (transform.position.x < leftDeadzone)
        {
            Destroy(gameObject);
        }*/
        /*else
        {
            transform.position = transform.position + (Vector3.right * ((moveSpeed + (float)playerScoreMulti) * movementSpeedRange)) * Time.deltaTime;

            if (transform.position.x > rightDeadzone)
            {
                Destroy(gameObject);
            }
        }*/
        if(!changer.changeDirection())
        {
            transform.position = transform.position + (Vector3.left * ((moveSpeed + (float)playerScoreMulti) * movementSpeedRange)) * Time.deltaTime;
            if (transform.position.x < leftDeadzone)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = transform.position + (Vector3.right * ((moveSpeed + (float)playerScoreMulti) * movementSpeedRange)) * Time.deltaTime;
            if (transform.position.x > rightDeadzone)
            {
                Destroy(gameObject);
            }
        }     
    }
}