using UnityEngine;
using SingletonBehavior;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonobehavior<GameManager>
{
    private void SLoad(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }


    protected override void Awake()
    {
        base.Awake();
    }


    public void MenuLoad()
    {
        
        SLoad("test1");
    }
    public void PlayerMoverLoad()
    {
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
