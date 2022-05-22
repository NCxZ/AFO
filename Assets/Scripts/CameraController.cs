using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    Vector3 diff;

    // Start is called before the first frame update
    void Start()
    {
        diff = ball.transform.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector3(transform.position.x,transform.position.y, ball.transform.position.z - diff.z);
        
    }
}
