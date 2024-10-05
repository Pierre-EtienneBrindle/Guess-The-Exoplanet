using UnityEngine;
using SingletonBehavior;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonobehavior<GameManager>
{
    private void SLoad(String scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }


    protected override void Awake()
    {
        base.Awake();
    }


    public void MenuSceneLoad()
    {
        //"Title scene"
        SLoad("test1");
    }


    public void GameSceneLoad()
    {
        SLoad("test2");
    }


    public void WikiSceneLoad()
    {
        SLoad("Wiki");
    }


    public void StarCounterSceneLoad()
    {
        SLoad("StarCounterMG")
    }

    public void MiniGame2SceneLoad()
    {
        SLoad("")
    }
}
