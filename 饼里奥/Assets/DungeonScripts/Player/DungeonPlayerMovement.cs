using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BulletHell
{
    public class DungeonPlayerMovement : MonoBehaviour
    {
        //枪的种类
        public GameObject[] guns;
        //玩家速度
        public float speed;
        //玩家键盘输入的向量
        private Vector2 input;
        //鼠标的向量
        private Vector2 mousePos;
        //玩家动画器
        private Animator animator;
        //玩家刚体
        private Rigidbody2D rigidbody;
        //玩家枪的种类
        private int gunNum;
        //炸弹数
        private int bomb_number;
        //炸弹预制体
        public GameObject bomb_explosion;
        //玩家碰撞体
        public Collider2D collider;
        //生命值
        public int blood = 10;
        //UI
        public Text bloodText;

        //面朝向
        private int face;

        void Start()
        {
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
            //初始化默认0号枪激活
            guns[0].SetActive(true);
            //
            bloodText.text = blood.ToString();
        }

        void Update()
        {
            SwitchGun();
            Move();
            DropBomb();
        }

        //玩家移动
        void Move()
        {   
            //获取ad水平位移
            input.x = Input.GetAxisRaw("Horizontal");
            //获取ws垂直位移
            input.y = Input.GetAxisRaw("Vertical");
            //获取面朝方向整数（-1，1）
            //float faceDirection = Input.GetAxisRaw("Horizontal");
            //玩家速度
            rigidbody.velocity = input.normalized * speed;
            //鼠标点击位置
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //按鼠标的方向改变人物方向
            if (mousePos.x > transform.position.x)
            {
                face = 1;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else
            {
                face = -1;
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }

            //input有输入时，将Running设为1
            if (input != Vector2.zero)
                animator.SetFloat("Running", 1);
            else
                animator.SetFloat("Running", 0);
        }

        //切枪
        void SwitchGun()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                guns[gunNum].SetActive(false);
                if (++gunNum > guns.Length - 1)
                {
                    gunNum = 0;
                }
                guns[gunNum].SetActive(true);
            }
        }

        //受伤
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //小怪碰撞
            if(collision.CompareTag("Enemy"))
            {
                //生命值-1
                blood -= 1;
                bloodText.text = blood.ToString();
                if (blood <= 0)
                {
                    FindObjectOfType<DungeonGameManager>().ResetStage();
                }
            }

            //地牢过关
            if (collision.CompareTag("Door"))
            {
                FindObjectOfType<DungeonGameManager>().DungeonNext = true;
                FindObjectOfType<DungeonGameManager>().NextDungeon();
            }
        }

        //放炸弹
        private void DropBomb()
        {
            if (Input.GetKeyDown(KeyCode.E))
            { //Check if bomb prefab is as
                //Instantiate(bomb_explosion, new Vector2(transform.position.x + 2, transform.position.y ), transform.rotation);
                //激活炸弹
                GameObject Bomb = ObjectPool.Instance.GetObject(bomb_explosion);
                Bomb.transform.position = new Vector2(transform.position.x + face * 2, transform.position.y );
            }
        }
        
    }
}