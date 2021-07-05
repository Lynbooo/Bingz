using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class bomb_explosion : MonoBehaviour
{
    public Animator anim; // ���ƶ����л�
    private Collider2D coll; // ��������ը����ײ��
    private Rigidbody2D rb2d; // ��������ը��������ֹ������Ļ
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

    // ��ⷶΧ���ӻ�
    void Explode()
    {

        //  anim.SetTrigger("Explosion");
        // Invoke("DestroyThisBomb", destroyBombTime);
        anim.SetTrigger("Explosion");
        // gamObject.SetActive(false);
        Destroy(gameObject);
    }

    // ը����ʧ���¼�����
    public void DestroyThisBomb()
    {
        anim.SetTrigger("Explosion");
        // gamObject.SetActive(false);
        Destroy(gameObject);
    }
   
}