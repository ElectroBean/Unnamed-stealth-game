using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    private bool canMove = true;

    Rigidbody rb;
    Vector3 moveAmount;

    // Getting stuff
    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveAmount = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        moveAmount *= Time.deltaTime * movementSpeed;
	}

    // Update but for physics stuff and other things
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + moveAmount);
    }
}
