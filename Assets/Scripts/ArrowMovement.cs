using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float moveSpeed = 80;
    public float leftDeadzone = -100;
    public float rightDeadzone = 60;
    public float movementSpeedRange;

    public LogicScript additionalArrowCalc;
    public bothSpawners changer;
    // Start is called before the first frame update
    void Start()
    {
        this.additionalArrowCalc = FindObjectOfType<LogicScript>();
        this.changer = FindObjectOfType<bothSpawners>();
    }

    // Update is called once per frame
    void Update()
    {
        arrowMovementReflection(this.getPlayerScore());
    }
    private int getPlayerScore()
    {
        return additionalArrowCalc.playerScore;
    }
    void arrowMovementReflection(int playerScoreMulti)
    {
        movementSpeedRange = Random.Range(1f, 1.7f);
        if (!changer.changeDirection())
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
