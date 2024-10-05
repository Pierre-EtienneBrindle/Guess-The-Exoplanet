using UnityEngine;
using SingletonBehavior;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonobehavior<GameManager>
{
    public void SLoad(string scene_name)
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
        Debug.Log("gugusss");
        SLoad("PlyaerMovementTest");
    }


    public void WikiLoad()
    {
        SLoad("Wiki");
    }


    public void StarCounterLoad()
    {
        SLoad("StarCounterMG");
    }

    public void MiniGame2Load()
    {
        SLoad("");
    }


    public void MiniGame3Load()
    {
        SLoad("");
    }
}
