using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCanvas : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
