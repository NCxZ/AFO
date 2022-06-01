using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public bool paused;
    public GameObject ball;
    public GameObject[] obstacles;

    Vector3 ballPos;
    Vector3 lastRoadPos = new Vector3(0, 0, 0);

    public GameObject textobj;
    public GameObject textobjGameEnder;
    Rigidbody ballrb;
    TMP_Text textmesh;
    TMP_Text textmeshEndGame;
    float score = 0;


    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Time.timeScale = 1;
        textmesh = textobj.GetComponent(typeof(TMP_Text)) as TMP_Text;
        textmeshEndGame = textobjGameEnder.GetComponent(typeof(TMP_Text)) as TMP_Text;
        ballrb = ball.GetComponent(typeof(Rigidbody)) as Rigidbody;
        setScore(0);
        Instantiate(obstacles[0], transform);
        Instantiate(obstacles[Random.Range(0, obstacles.Length)],  new Vector3(0, 0, 20), transform.rotation);
        ballrb.velocity = new Vector3(0, 0, 10);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Time.timeScale !=0)
        {
            score = (score + .3f);
            setScore(score);
            ballPos = ball.transform.position;

            if (ballPos.z > lastRoadPos.z)
            {
                lastRoadPos = lastRoadPos + new Vector3(0, 0, 20);
                Instantiate(obstacles[ Random.Range(0, obstacles.Length) ], lastRoadPos + new Vector3(0, 0, 20), transform.rotation);
            }

            if (ballrb.velocity.z == 0 || ballPos.y < -5)
            {
                endGame();

            }
        }
        else
        {
            if (!paused && Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                textobjGameEnder.active = false;
                SceneManager.LoadScene("Game");
            }
        }




    }

    [System.Obsolete]
    public void endGame()
    {
        textmeshEndGame.text = "Game Over \n Score: " + ((int)score).ToString();
        textobjGameEnder.active = true;
        Time.timeScale = 0;
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
