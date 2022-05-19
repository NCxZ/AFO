using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public Rigidbody rb;
    public float zSpeed = 10f;
    float topSpeed = 1;

    private Vector2 startTocuhPos;
    private Vector2 currentPos;
    private Vector2 lastPos;
    private Vector2 endTocuhPos;
    private bool stopTouch;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, zSpeed); // Keep Speed

        Swipe();

        
    }
    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )
        {
            startTocuhPos = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved )
        {
            Touch t1 = Input.GetTouch(0);
            lastPos = currentPos;
            currentPos = t1.position;
            Vector2 Distance = currentPos - lastPos;
            rb.position = new Vector3(rb.position.x + (t1.deltaPosition.x / 300), rb.position.y, rb.position.z);
            //rb.velocity = new Vector3(t1.deltaPosition.x/6, rb.velocity.y, rb.velocity.z);
        }
    }
}
