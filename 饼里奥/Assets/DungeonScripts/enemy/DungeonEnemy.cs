using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemy : MonoBehaviour
{
    //起始位置
    private Vector3 staringPosition;
    //刚体
    public Rigidbody2D Rigidbody;

    //血量
    public int blood = 5;

    //面向
    private bool FaceLeft = false;

    //速度
    public float speed;

    //敌人动画
    public Animator animator;

    //碰撞体
    public Collider2D collider;

    public Transform leftPoint,rightPoint;

    private float left,right;

    // Start is called before the first frame update
    void Start()
    {
        staringPosition = transform.position;
        left = leftPoint.position.x;
        right = rightPoint.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //移动
    void Movement()
    {
        //向右
        if(!FaceLeft)
        {
            Rigidbody.velocity = new Vector2(speed,Rigidbody.velocity.y);
            if(transform.position.x > right)
            {
                transform.localScale = new Vector3(-1,1,1);
                FaceLeft = true;
            }
        }
        //向左
        else if (FaceLeft)
        {
            Rigidbody.velocity = new Vector2(-speed,Rigidbody.velocity.y);
            if(transform.position.x < left)
            {
                transform.localScale = new Vector3(1,1,1);
                FaceLeft = false;
            }
        }
    }

    public static Vector3 GetRandDir(){
        return new Vector3(UnityEngine.Random.Range(-1f,1f),UnityEngine.Random.Range(-1f,1f)).normalized;
    }

    private Vector3 GetRoamingPosition(){
        return staringPosition + GetRandDir() * Random.Range(10f,20f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Bullet"))
        {
            //生命值-1
            blood -= 1;
            if (blood <= 0)
            {
                Destroy(gameObject);
            }


        }

        if(collision.CompareTag("Rocket"))
        {
            //生命值-5
            blood -= 5;
            if (blood <= 0)
            {
                Destroy(gameObject);
            }

            
        }
    }
    
}
