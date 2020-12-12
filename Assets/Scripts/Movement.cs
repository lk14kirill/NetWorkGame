using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Movement : NetworkBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    
    void Update()
    {
      
        RpcMove();
    }
   
    private void CmdMove(Vector3 pos)
    {
        
    }
    [ClientRpc]
    private void RpcMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        transform.Translate(move * speed * Time.deltaTime); ;
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
