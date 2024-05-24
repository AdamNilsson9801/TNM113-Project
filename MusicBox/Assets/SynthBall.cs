using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscJack;
using Unity.VisualScripting;

public class SynthBall : MonoBehaviour
{
    public float initialSpeed = 10f;
    public Rigidbody2D rb;

    [SerializeField] string ipAddress = "127.0.0.1";
    [SerializeField] int port = 12345;

    OscClient client;

    private string[] ballTypes = { "chord", "tone" };
    private string[] majorChords = { "C", "G", "D", "A", "E", "B", "Fiss", "Ciss", "F", "Bess" };
    private string[] minorChords = { "A", "E", "B", "Fiss", "Ciss", "Giss", "Diss", "Bess", "F", "C" };

    private string ballType = null;

    // Start is called before the first frame update
    void Start()
    {
        //Set up client
        client = new OscClient(ipAddress, port);

        if (rb != null)
        {
            rb.gravityScale = 0f; //No gravity

            Vector2 forceVec = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
            rb.AddForce(forceVec * initialSpeed, ForceMode2D.Impulse);
        }
        Camera camera = Camera.main;
        camera.GetComponent<FollowBall>().SetActiveBall(gameObject);

        InvokeRepeating("CheckVelocity", 0f, 30f); //Clamp velocity to 10f
    }

    public void SetBallType(string _ballType)
    {
        ballType = _ballType;
    }

    public string GetBallType()
    {
        return ballType;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //float collisionAngle = Mathf.Atan2(collision.contacts[0].normal.y, collision.contacts[0].normal.x);
        //float collisionAngleDegrees = collisionAngle * Mathf.Rad2Deg;
        //Debug.Log("Collision Angle: " + collisionAngleDegrees);


        if (collision.gameObject.tag == "pin")
        {

            //Send collision message
            if (ballType == ballTypes[0]) //chord
            {
                float angle = CollisionAngle(collision.contacts[0]);

                string chordType = majorChords[(int)Random.Range(0, majorChords.Length)];
                string msg = "chord " + chordType + " " + angle.ToString();


                client.Send("/collision", msg); //msg = "chord A 123.123"
            }
            else
            {
                float angle = CollisionAngle(collision.contacts[0]);
                string msg = "tone " + angle.ToString();
                client.Send("/collision", msg);
            }

        }
    }

    private float CollisionAngle(ContactPoint2D contact)
    {
        Vector2 direction = (contact.point - (Vector2)transform.position) * -1f;
        direction.Normalize();

        // For Debugging
        Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + direction, Color.red, 1f);

        //Calculate angle from direction vector.
        float angle = Vector2.SignedAngle(Vector2.right, direction); //gives an angle between 0 to 180 and -180 to 0.

        if (angle < 0)
        {
            angle += 360;
        }

        return angle;
    }


    private void CheckVelocity()
    {
        // Check if the velocity magnitude is NOT 10 anymore
        if (Mathf.Abs(rb.velocity.magnitude - 10f) > 0.0001)
        {
            Debug.Log(rb.velocity.magnitude);
            rb.velocity = rb.velocity.normalized * initialSpeed;
        }
    }
}