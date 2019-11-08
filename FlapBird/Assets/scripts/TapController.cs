using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour
{
    public float tapForce = 250;
    public float tiltSmooth = 2;
    public Vector3 startPos;

    private Rigidbody2D rigidbody;
    // fancy form of rotation
    private Quaternion downRotation;
    private Quaternion forwardRotation;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
    }

    void Update()
    {
        // 0: left, 1: right
        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = forwardRotation;
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        // source to target value in certain time
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ScoreZone")
        {
            // register score event
            // play sound
        }

        if (collider.gameObject.tag == "DeadZone")
        {
            rigidbody.simulated = false;
            // register a dead event
            // play a sound
        }
    }
}