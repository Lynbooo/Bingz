using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBossSight : DungeonBoss
{
    //发现玩家
    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            //将玩家位置信息交给PlayerTarget
            PlayerTarget = player.transform;
        }
    }
    
    //玩家退出
    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            //玩家离开视野时将PlayerTarget置为空
            PlayerTarget = null;
        }
    }

}
