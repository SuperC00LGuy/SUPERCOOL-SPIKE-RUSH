using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawnerScript : MonoBehaviour
{
    public GameObject apple1;
    // Start is called before the first frame update
    void Start()
    {
        spawnApple();
    }

    // Update is called once per frame
    void Update()
    {
       if(apple1 == null)
        {
            spawnApple();
        }
    }
    public void spawnApple()
    {
        float xPoint = Random.Range(-25, 15);
        float yPoint = Random.Range(-20, 21);
        Instantiate(apple1, new Vector3(xPoint, yPoint, 0), transform.rotation);
    } 
}
