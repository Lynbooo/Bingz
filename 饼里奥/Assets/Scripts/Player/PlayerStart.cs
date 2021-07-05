///////////////////////////////////////////////////////////////////////
//
//      PlayerStart.cs

//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Used as a starting point in the level
public class PlayerStart : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        Vector3 pos = new Vector3(0, 0, -5.0f);
        GameData data = SaveLoadManager.data;
        
        // If player saves in this room - set his coords to the saves ones设定当前坐标
        if (data.valid && data.sceneIndex == NewSceneManager.SceneIndex)
        {
            pos.x = data.playerX;
            pos.y = data.playerY;
        }
        else
        {
            // Otherwise use player start coords初始坐标
            pos.x = transform.position.x;
            pos.y = transform.position.y;
        }

        GameObject newPlayer = Instantiate(player, pos, Quaternion.identity);
        newPlayer.name = player.name;

        //TODO: load the direction player is looking in. Somehow. No idea how though.

        // If currently in stage hub - give "infinite" jump无限跳
        if (NewSceneManager.SceneName == "sStageHub")
        {
            newPlayer.GetComponent<Player>().jumpCount = uint.MaxValue;
        }

        Destroy(gameObject);
    }
}
