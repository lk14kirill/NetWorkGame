using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class UISlider : NetworkBehaviour
{
    public Slider slider;
    public DamageManager damageManager;

    private void Start()
    {
        damageManager = GetComponentInParent<DamageManager>();
    }
    [ClientCallback]
    private void RpcChangeBar()
    {
        slider.value = damageManager.health;

    }
    
    private void Update()
    {
        
        RpcChangeBar();
    }
}
