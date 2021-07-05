using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //攻击间隔
    public float interval;
    //伤害
    public int gunDamage;
    //子弹类
    public GameObject bulletPrefab;
    //弹壳类
    //public GameObject shellPrefab;
    //弹舱朝向（枪口）
    protected Transform muzzlePos;
    //弹壳
    //protected Transform shellPos;
    //鼠标点击
    protected Vector2 mousePos;
    //射击方向
    protected Vector2 direction;
    //计时器
    protected float timer;
    //记录反转y
    protected float Y;
    //动画器
    protected Animator animator;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        muzzlePos = transform.Find("Muzzle");
        Y = transform.localScale.y;
    }

    protected virtual void Update()
    {
        Move();
        Shoot();
    }

    //枪支随鼠标旋转时反转
    protected virtual void Move()
    {
        //鼠标点击位置
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //鼠标x小于枪时，反转Scale的y值
        if (mousePos.x < transform.position.x)
            transform.localScale = new Vector3(Y, -Y, 1);
        else
            transform.localScale = new Vector3(Y, Y, 1);

    }

    protected virtual void Shoot()
    {
        //鼠标位置-枪位置
        direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        //枪指向鼠标方向
        transform.right = direction;

        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                timer = 0;
        }

        //鼠标左键点击，计时器刷新即可进行攻击（Fire）
        if (Input.GetButton("Fire1"))
        {
            if (timer == 0)
            {
                timer = interval;
                Fire();
            }
        }
    }

    protected virtual void Fire()
    {
        //触发器
        animator.SetTrigger("Shoot");

        //在枪口位置生成子弹预制体
        //GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = muzzlePos.position;

        //子弹略有偏移
        float angel = Random.Range(-5f, 5f);
        bullet.GetComponent<DungeonBullet>().SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * direction);

    }
}
