using UnityEngine;
using SingletonBehavior;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonobehavior<GameManager>
{
    private void SLoad(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }


    public void ChangeScene(PossibleScenes scene)
    {
        switch (scene)
        {
            case PossibleScenes.Menu:
                SLoad("title scene");
                break;
            case PossibleScenes.MiniG1:
                SLoad("PlyaerMovementTest");
                break;
            case PossibleScenes.MiniG2:
                SLoad("");
                break;
            case PossibleScenes.MiniG3:
                SLoad("");
                break;
            case PossibleScenes.MiniG4:
                SLoad("");
                break;
        }
    }


    protected override void Awake()
    {
        base.Awake();
    }
}


public enum PossibleScenes {
    Menu,
    MiniG1,
    MiniG2,
    MiniG3,
    MiniG4
}
