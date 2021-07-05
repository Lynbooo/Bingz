using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBoss : MonoBehaviour
{
    //boss漫游速度
    public float speed1;
    //boss追击速度
    public float speed2;

    //boss动画器
    private Animator animator;
    //boss刚体
    private Rigidbody2D rigidbody;

    //起始位置
    private Vector3 startPosition;

    //漫游位置
    private Vector3 roamPosition;

    //生命值
    public int blood = 100;

    //是否射击
    public bool isShooting;
    //弹舱朝向（枪口）
    protected Transform muzzlePos;
    //激光攻击间隔
    public float interval1;
    //计时器
    private float timer;

    //玩家
    public static Transform PlayerTarget;

    void Start()
    {
        startPosition = transform.position;
        roamPosition = GetRandomDir();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        muzzlePos = transform.Find("Muzzle");
    }

    void Update()
    {
        if(PlayerTarget == null)
            RandomMove();
        else
        {
            Pursuit();
            Fire();
            Attack();
        }
       
    }
    //获取随机位置
    public Vector3 GetRandomDir()
    {
        Vector3 randomDir = new Vector2(UnityEngine.Random.Range(-1f,1f),UnityEngine.Random.Range(-1f,1f)).normalized;
        return startPosition + randomDir * Random.Range(2f,3f);
    }

    //巡逻
    public void RandomMove()
    {
        // if (roamPosition.x != transform.position.x && roamPosition.y != transform.position.y)
        // {
        //     MoveTo(roamPosition);
        // }
        // else
        // {
        //     roamPosition = GetRandomDir();
        // }
        MoveTo(roamPosition,speed1);
        if(roamPosition == transform.position)
            roamPosition = GetRandomDir();
        
    }

    //移动至
    void MoveTo(Vector2 position,float speed)
    {
        Vector2 direction;
        direction.x = position.x - transform.position.x;
        direction.y = position.y - transform.position.y;
        //漫游速度
        rigidbody.velocity =  direction* speed;

        //按鼠标的方向改变人物方向
        if (position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    
    //追击
    private void Pursuit()
    {
        if(PlayerTarget != null)
            MoveTo(PlayerTarget.position,speed2);

    }

    //攻击
    private void Attack()
    {
        //生命值低于一半，开始暴走激光攻击
        if(blood >= 50)
        {
            // if (timer != 0)
            // {
            //     timer -= Time.deltaTime;
            //     if (timer <= 0)
            //         timer = 0;
            // }

            // if(timer == 0)
            // {
            //     isShooting = true;
            //     timer = interval1;
            // }

            
        }
        // if (isShooting == true)
        // {
        //     Fire();
        //     // isShooting = false;
        // }
    }

    //激光攻击
    private void Fire()
    {
        //打出射线
        RaycastHit2D hit2D = Physics2D.Raycast(transform .position,PlayerTarget.position,30);

        //又枪口位置和碰撞点位置绘制射线
        Debug.DrawRay(transform.position,hit2D.point);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Bullet"))
        {
            //生命值-1
            blood -= 1;
            if (blood <= 0)
            {
                FindObjectOfType<DungeonGameManager>().GameOver();
            }


        }

        if(collision.CompareTag("Rocket"))
        {
            //生命值-5
            blood -= 5;
            if (blood <= 0)
            {
                FindObjectOfType<DungeonGameManager>().GameOver();
            }

            
        }
    }
}


