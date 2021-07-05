///////////////////////////////////////////////////////////////////////
//
//      ChooseRandomSprite.cs
//
///////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
// Small helper class. When attached to the object picks a random sprite for
// SpriteRenderer from the array
public class ChooseRandomSprite : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
