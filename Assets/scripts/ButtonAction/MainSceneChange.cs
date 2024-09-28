using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneChange", menuName = "Scriptable/SceneChange", order = 1)]
public class MainSceneChange : ScriptableObject
{
    public void ChangeToMemoryTest()
    {
        SceneManager.LoadScene(3);
    }
    public void ChangeToHwatoo()
    {
        SceneManager.LoadScene(2);
    }
    public void ChangeToColorQuiz()
    {
        SceneManager.LoadScene(1);
    }
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
