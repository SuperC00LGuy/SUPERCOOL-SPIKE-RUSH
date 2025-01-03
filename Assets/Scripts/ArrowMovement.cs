using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float moveSpeed = 80;
    public float leftDeadzone = -100;
    public float rightDeadzone = 60;
    public int reflection;
    public float movementSpeedRange;

    public LogicScript additionalArrowCalc;
    // Start is called before the first frame update
    void Start()
    {
        this.additionalArrowCalc = FindObjectOfType<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        arrowMovementReflection(reflection, this.getPlayerScore());
    }
    private int getPlayerScore()
    {
        return additionalArrowCalc.playerScore;
    }
    void arrowMovementReflection(int reflection, int playerScoreMulti)
    {
        movementSpeedRange = Random.Range(1f, 1.7f);
        if (reflection == 0)
        {
            transform.position = transform.position + (Vector3.left * (moveSpeed + (float)playerScoreMulti) * movementSpeedRange) * Time.deltaTime;

            if (transform.position.x < leftDeadzone)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

            if (transform.position.x > rightDeadzone)
            {
                Destroy(gameObject);
            }
        }
        /*
         arrowMovementReflection(bool reflect, int playerScoreMulti)
        {
            Same as up top but
        }
         */
    }
}
