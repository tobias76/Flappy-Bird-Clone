using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    Vector3 birdVelocity = Vector3.zero;

    public Vector3 gravity;
    public Vector3 flapVelocity;

    public float horizontalSpeed = 1f;
    public float maxBirdSpeed = 5f;

    float birdAngle = 0;

    bool birdFlapped = false;

    // This is where I update the games physics
    void FixedUpdate()
    {
        /* Adds gravity to the current velocity dependent on the time that has passed. 
          This means that the birds dropping speed will get faster as time passes. */

        birdVelocity += gravity * Time.deltaTime;
        birdVelocity.x = horizontalSpeed;

        //This section checks to see if the bird has flapped and if it has then it adds the flaps velocity to the bu
        if(birdFlapped == true)
        {
            birdFlapped = false;

            //This prevents falling directly after a flap
            if(birdVelocity.y < 0)
            {
                birdVelocity.y = 0;
            }

            birdVelocity += flapVelocity;
        }

        // This section here limits the birds velocity to the maximum speed
        birdVelocity = Vector3.ClampMagnitude(birdVelocity, maxBirdSpeed);

        transform.position += birdVelocity * Time.deltaTime;
    }

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // This sets the birdFlapped boolean to true on a space press or left mouse click
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            birdFlapped = true;
        }
	}
}
