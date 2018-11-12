using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour {
    Rigidbody2D rb;
    public float speed = 2.0f;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void fixedUpdate () {
        if (Input.GetKey (CustomInputs.Inputs.right)) {
            rb.velocity = new Vector2 (speed, rb.velocity.y);
            Debug.Log ("A");
        }

    }
}