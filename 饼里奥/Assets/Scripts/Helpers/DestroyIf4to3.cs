///////////////////////////////////////////////////////////////////////
//
//      DestroyIf4to3.cs

//
///////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Small helper that destroys the object if current resolution is 4:3
public class DestroyIf4to3 : MonoBehaviour
{
    void Start()
    {
        Resolution curRes = GameManager.Instance.DisplayManager.Resolution;
        if ((float)curRes.width / (float)curRes.height < 1.76f)
        {
            Destroy(gameObject);
        }
    }
}
