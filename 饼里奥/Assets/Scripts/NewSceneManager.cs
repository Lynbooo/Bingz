///////////////////////////////////////////////////////////////////////
//
//      NewSceneManager.cs

//
///////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

// Wrapper around Unity's scene management
// Has ability to change rooms with fadeIn/fadeOut transitions切入切除特效
public static class NewSceneManager
{
    public static int SceneIndex//场景索引
    {
        get
        {
            return SceneManager.GetActiveScene().buildIndex;//动态获取场景的索引
        }
    }

    public static string SceneName
    {
        get
        {
            return SceneManager.GetActiveScene().name;//动态获取场景的名字
        }
    }

    public static void NextScene(float fadeOut = 0.0f, float fadeIn = 0.0f)
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > index)
        {
            GotoScene(index,fadeOut, fadeIn); //跳转至下一个场景
        }
    }

    public static void PrevScene(float fadeOut = 0.0f, float fadeIn = 0.0f)
    {
        int index = SceneManager.GetActiveScene().buildIndex - 1;
        if (SceneManager.sceneCountInBuildSettings > index && index >=0)
        {
            GotoScene(index, fadeOut, fadeIn);
        }
    }
    
    public static void GotoScene(int index, float fadeOut = 0.0f, float fadeIn = 0.0f)
    {
        if (fadeOut > Mathf.Epsilon || fadeIn > Mathf.Epsilon)
        {
            LevelTransition.LoadLevel(index, fadeOut, fadeIn, Color.black);
        }
        else
        {
            SceneManager.LoadScene(index);
        }
    }

    public static void GotoScene(string index, float fadeOut = 0.0f, float fadeIn = 0.0f)
    {
        if (fadeOut > Mathf.Epsilon || fadeIn > Mathf.Epsilon)
        {
            LevelTransition.LoadLevel(index, fadeOut, fadeIn, Color.black);
        }
        else
        {
            SceneManager.LoadScene(index);
        }
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
