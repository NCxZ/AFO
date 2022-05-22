using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] obstacles;

    Vector3 ballPos;
    Vector3 lastRoadPos = new Vector3(0, 0, 0);

    public GameObject textobj;
    TMP_Text textmesh;
    float score = 0;


    // Start is called before the first frame update
    void Start()
    {
        textmesh = textobj.GetComponent(typeof(TMP_Text)) as TMP_Text;
        setScore(0);
        Instantiate(obstacles[0], transform);
    }

    // Update is called once per frame
    void Update()
    {
        score = score + .3f;
        setScore(score);

        ballPos = ball.transform.position;

        if (ballPos.z > lastRoadPos.z)
        {
            lastRoadPos = lastRoadPos + new Vector3(0, 0, 20);
            Instantiate(obstacles[ Random.Range(0, obstacles.Length) ], lastRoadPos, transform.rotation);
        }

        if (ballPos.y < -5)
        {
            
            SceneManager.LoadScene("Game");
        }
        // Time.timeScale = 0


    }
    public void setScore(float num)
    {
        textmesh.text = ((int)num).ToString();
    }
    public void incrementScore()
    {
        textmesh.text = (int.Parse(textmesh.text) + 1).ToString();
    }
}
