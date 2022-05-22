using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public Rigidbody rb;
    public float zSpeed = 10f;
    public Camera cam;
    bool swiping = true;
    int layers;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        layers = LayerMask.GetMask("TransparentFX");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, zSpeed); // Keep Speed

    }
    void Update()
    {
        Swipe();
    }
    

    public void Swipe()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector3 rayPoint;
                Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out RaycastHit raycastHitInfo ,10 , layers))
                {
                    rayPoint = raycastHitInfo.point;
                    if (Mathf.Abs(rayPoint.x - transform.position.x) < .2)
                    {
                        swiping = true;
                    }
                }

            }
            else if ((Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary) && swiping)
            {
                Vector3 rayPoint;
                Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out RaycastHit raycastHitInfo, 10, layers))
                {
                    rayPoint = raycastHitInfo.point;
                    Debug.Log(raycastHitInfo.point);

                    if (rayPoint.x != rb.transform.position.x)
                    {
                        rb.velocity = new Vector3((rayPoint.x - rb.transform.position.x) * 15, rb.velocity.y, rb.velocity.z);
                    }
                }
                else
                {
                    swiping = false;
                }

            }
        }
        else
        {
            swiping = false;
            //rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
    }
}
