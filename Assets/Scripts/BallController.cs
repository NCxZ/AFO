using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public Rigidbody rb;
    public float zSpeed = 10f;
    float topSpeed = 1;


    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, zSpeed); // Keep Speed

        Swipe();

        
    }
    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )
        {
            Vector3 tp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            // TRÝAL Physics.Raycast(tp,Camera.main.)
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved )
        {
            Vector3 tp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Touch t1 = Input.GetTouch(0);
            rb.position = new Vector3(rb.position.x + (t1.deltaPosition.x / 300), rb.position.y, rb.position.z);
            //rb.velocity = new Vector3(t1.deltaPosition.x/6, rb.velocity.y, rb.velocity.z);
        }
    }
}
