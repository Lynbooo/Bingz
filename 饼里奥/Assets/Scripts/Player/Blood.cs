///////////////////////////////////////////////////////////////////////
//
//      Blood.cs
//    用粒子来实现喷血的功能
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Controls the behaviour of the player's blood particles
public class Blood : MonoBehaviour
{
    bool landed = false;
    NewCollider2D obstaclesController;
    Vector3 velocity;

    void Start()
    {
        // Used for detecting collision with obstacles, so the particles get 'stuck' on the objects
        // 血粒子碰到方块停止
        obstaclesController = GetComponent<NewCollider2D>();

        // Random speed
        velocity.x = Random.Range(-6.0f, 6.0f);
        velocity.y = Random.Range(-6.0f, 6.0f);
    }
    
    void FixedUpdate()
    {
        // Small optimization. If is already stuck on the block - do nothing
        if (landed)
        {
            return;
        }//血粒子已经碰到方块

        // Apply gravity to the current speed and move the particle
        velocity.y += GM.gravity * (0.3f + Random.Range(0.1f,0.4f));
        obstaclesController.Move(velocity);

        // Stop the particle from moving if collision with obstacles detected
        if (obstaclesController.collisions.below || obstaclesController.collisions.above ||
            obstaclesController.collisions.left || obstaclesController.collisions.right)
        {
            landed = true;
        }//碰到上下左右的方块粒子停止运动
    }
}
