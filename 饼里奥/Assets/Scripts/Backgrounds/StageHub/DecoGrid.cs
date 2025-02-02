﻿///////////////////////////////////////////////////////////////////////
//
//      DecoGrid.cs

//
///////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// A decorative grid for stage hub level.
// Moves 50 times a second by 1 pixel in the top left direction
public class DecoGrid : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position += Vector3.up;
        transform.position += Vector3.left;

        if (transform.position.x < 0 || transform.position.y > 640)
        {
            Destroy(gameObject);
        }
    }
}
