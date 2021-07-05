using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGameManager : MonoBehaviour
{
    public int totalBoxs;

    public int finishedBoxs;

    public bool DungeonNext;

    public void CheckBoxFinish()
    {
        if (finishedBoxs == totalBoxs)
        {
            print("Win!");
            StartCoroutine(LoadNextStage());
        }
    }

    //地牢下一关
    public void NextDungeon()
    {
        if (DungeonNext == true)
        {
            StartCoroutine(LoadNextStage());
        }
    }

    IEnumerator LoadNextStage()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetStage();
        }
    }

    public void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
