﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Gun
{
    //火箭弹数量
    public int rocketNum = 3;
    //发射间隔角度
    public float rocketAngle = 15;

    //射击函数
    protected override void Fire()
    {
        animator.SetTrigger("Shoot");
        //协程0.2秒
        StartCoroutine(DelayFire(.2f));
    }

    IEnumerator DelayFire(float delay)
    {
        yield return new WaitForSeconds(delay);

        int median = rocketNum / 2;
        for (int i = 0; i < rocketNum; i++)
        {
            GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
            bullet.transform.position = muzzlePos.position;

            if (rocketNum % 2 == 1)
            {
                bullet.transform.right = Quaternion.AngleAxis(rocketAngle * (i - median), Vector3.forward) * direction;
            }
            else
            {
                bullet.transform.right = Quaternion.AngleAxis(rocketAngle * (i - median) + rocketAngle / 2, Vector3.forward) * direction;
            }
            bullet.GetComponent<Rocket>().SetTarget(mousePos);
        }
    }
}
