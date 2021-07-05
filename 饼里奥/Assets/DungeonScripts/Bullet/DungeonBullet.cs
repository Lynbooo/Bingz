using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBullet : MonoBehaviour
{
    //子弹发射速度
    public float speed;
    //子弹爆炸预制体
    public GameObject explosionPrefab;
    //伤害
    private int damage = 1;
    //刚体
    new private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    //设置刚体速度
    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    //子弹打中障碍物触发爆炸特效并销毁
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        exp.transform.position = transform.position;

        // Destroy(gameObject);
        ObjectPool.Instance.PushObject(gameObject);
    }
}
