using UnityEngine;
using SingletonBehavior;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonobehavior<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }


    public void MenuSceneLoad()
    {
        //"Title scene"
        SceneManager.LoadScene("test1");
    }


    public void GameSceneLoad()
    {
        SceneManager.LoadScene("test2");
    }


    public void WikiSceneLoad()
    {
        SceneManager.LoadScene("Wiki");
    }
}
