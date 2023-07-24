using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMag : MonoBehaviour
{
    public void EnterGame()
    {
        //加载游戏主界面
        SceneManager.LoadScene(1);

    }

    //退出游戏使用Application.Quit()，但在 editor 模式下使用 Application.Quit()是没用的，要用 EditorApplication.isPlaying = false。
    public void ExitGame()
    {
        //Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
    public void EnterMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
