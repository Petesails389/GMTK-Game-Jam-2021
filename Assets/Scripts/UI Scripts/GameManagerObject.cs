using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Manager/GameManager")]
public class GameManagerObject : ScriptableObject
{
    [SerializeField] string gameScene;
    public void StartGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
