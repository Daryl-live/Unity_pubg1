using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMag : MonoBehaviour
{
    public void EnterGame()
    {
        //������Ϸ������
        SceneManager.LoadScene(1);

    }

    //�˳���Ϸʹ��Application.Quit()������ editor ģʽ��ʹ�� Application.Quit()��û�õģ�Ҫ�� EditorApplication.isPlaying = false��
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
