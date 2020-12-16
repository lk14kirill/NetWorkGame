using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DamageManager : NetworkBehaviour
{

    [SyncVar]
    public float health = 100;

    public UISlider slider;

    private void Start()
    {
        slider = GetComponentInChildren<UISlider>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Die();

    }

    private void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
