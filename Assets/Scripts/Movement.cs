using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody))]

public class Movement : NetworkBehaviour
{
    CharacterController controller;
    private float horizontal;
    private float vertical;
    public float speed;
    Rigidbody rb;
    public float turnSmoothnessTime = 0.1f;
    public float turnSmoothnessVel;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
            controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    
    void Update()
    {
        if (isLocalPlayer) {
            Move();
            
            }
    }




    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(move);
        if(move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothnessVel, turnSmoothnessTime);  //Brackeys юхууу
            transform.rotation = Quaternion.Euler(0f, angle, 0f) ;
            controller.Move(move * speed * Time.deltaTime);
        }
    
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }
    }
}
