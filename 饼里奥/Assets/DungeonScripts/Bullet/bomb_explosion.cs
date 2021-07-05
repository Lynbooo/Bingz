using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class bomb_explosion : MonoBehaviour
{
    public Animator anim; // 控制动画切换
    private Collider2D coll; // 用于脱离炸弹碰撞体
    private Rigidbody2D rb2d; // 用于设置炸弹重力防止掉出屏幕
    public Vector2 startSpeed;
    public float delayExplodeTime;
    public float destroyBombTime;
    void Start()
    {
        anim = GetComponent<Animator>();
        //coll = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(startSpeed.x ,startSpeed.y);
        Invoke("Explode",delayExplodeTime);
       // Destroy(gameObject);
    }

    void Update()
    {
    }

    // 检测范围可视化
    void Explode()
    {

        //  anim.SetTrigger("Explosion");
        // Invoke("DestroyThisBomb", destroyBombTime);
        anim.SetTrigger("Explosion");
        // gamObject.SetActive(false);
        Destroy(gameObject);
    }

    // 炸弹消失的事件方法
    public void DestroyThisBomb()
    {
        anim.SetTrigger("Explosion");
        // gamObject.SetActive(false);
        Destroy(gameObject);
    }
   
}