using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthBall : MonoBehaviour
{
    public float initialSpeed = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (rb != null)
        {
            rb.gravityScale = 0f; //No gravity

            Vector2 forceVec = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
            rb.AddForce(forceVec * initialSpeed, ForceMode2D.Impulse);
        }

        InvokeRepeating("CheckVelocity", 0f, 30f); //Clamp velocity to 10f
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        float collisionAngle = Mathf.Atan2(collision.contacts[0].normal.y, collision.contacts[0].normal.x);

        float collisionAngleDegrees = collisionAngle * Mathf.Rad2Deg;

        Debug.Log("Collision Angle: " + collisionAngleDegrees);

    }


    private void CheckVelocity()
    {
        Debug.Log("CheckVelocity");
        // Check if the velocity magnitude is NOT 10 anymore
        if (Mathf.Abs(rb.velocity.magnitude - 10f) > 0.0001)
        {
            Debug.Log(rb.velocity.magnitude);
            rb.velocity = rb.velocity.normalized * initialSpeed;
        }
    }
}