using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody  rb;
    public float movespeed = 5;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate(){

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = (transform.right * moveX) + (transform.forward * moveZ);

        rb.AddForce(movement * movespeed, ForceMode.Force);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Goal"))
        {
            Debug.Log("YOU WIN");
        }else if (other.CompareTag("DeathPlane"))
        {   
            
            rb.position = startPosition;
            
            rb.velocity = new Vector3(0,0,0);
        }
    }
}
