using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordQi : MonoBehaviour
{
    //刚体
    new private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
