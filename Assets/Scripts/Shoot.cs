using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Shoot : NetworkBehaviour
{
    
    public Transform ShootPos;
    public GameObject bullet;
    public float speed;
    public GameObject player;
    private DamageManager damageManager;

    void Start()
    {
        damageManager = this.GetComponent<DamageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdCreateAndGo();
            print("ShootPressed");
        }
    }

    [Command]
    public void CmdCreateAndGo()
    {
        //CreateAndGo();
        RpcCreateAndGo();
    }
    [ClientRpc]
    public void RpcCreateAndGo()
    {
        CreateAndGo();
    }
    public void CreateAndGo()
    {
        GameObject bulletGO = Instantiate(bullet, ShootPos.position, player.transform.rotation);
        Destroy(bulletGO, 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isServer)
        {
            if (collision.transform.CompareTag("bullet"))
            {
                CmdTakeDamage();
            }
        }
    }

    //[Command]
    void CmdTakeDamage()
    {
        damageManager.TakeDamage(30);
    }
}
