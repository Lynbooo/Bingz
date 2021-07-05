///////////////////////////////////////////////////////////////////////
//
//      DestructibleBlock.cs

//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Represents a destructible block - gimmick from stage 3
// In general, destructible block behaves like a normal obstacle, but when the bulelt collides
// with it - Destruct() is called
public class DestructibleBlock : MonoBehaviour
{
    // Destroys the object in a fancy way
    public void Destruct()
    {
        // With particles
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();

        ps.transform.parent = null;
        ps.Play();

        // And sound
        GameManager.Instance.PlaySound("Destruct");

        // BOOOOM. dead
        Destroy(gameObject);
    }
}
