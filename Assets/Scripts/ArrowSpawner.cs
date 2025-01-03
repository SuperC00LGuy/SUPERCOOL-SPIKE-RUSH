/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrow;
    public float spawnRate = 12;
    private float timer = 0;
    public float heightOffset = 5;
    public int scalingOffset = 7;

    public LogicScript additionalSpawnerCalc;
    // Start is called before the first frame update
    void Start()
    {
        this.additionalSpawnerCalc = FindObjectOfType<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.getPlayerScore() > this.scalingOffset && spawnRate > 7)
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
            spawnArrow();
            timer = 0;
        }
    }
    private int getPlayerScore()
    {
        return additionalSpawnerCalc.playerScore;
    }

    void spawnArrow()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(arrow, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}*/
