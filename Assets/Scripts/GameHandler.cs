using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] obstacles;

    Vector3 ballPos;
    Vector3 lastRoadPos = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(obstacles[0], transform);
    }

    // Update is called once per frame
    void Update()
    {

        ballPos = ball.transform.position;

        if (ballPos.z > lastRoadPos.z)
        {
            lastRoadPos = lastRoadPos + new Vector3(0, 0, 20);
            Instantiate(obstacles[ Random.Range(0, obstacles.Length) ], lastRoadPos, transform.rotation);
        }

        
    }
}
