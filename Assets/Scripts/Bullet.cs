using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Bullet : NetworkBehaviour
{

    public float speed;
    public GameObject explosion;
    public Transform shootPos;
    Rigidbody rb;
    
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Go();
    }
    void Go()
    {

        rb.AddForce(shootPos.forward*speed, ForceMode.Impulse);
        Debug.Log("go");
    }
    private void OnCollisionEnter(Collision collision)
    {
        explosion.SetActive(true);
        Destroy(this.transform.gameObject, .3f);
    }
}
