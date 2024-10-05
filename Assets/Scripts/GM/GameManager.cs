using UnityEngine;
using SingletonBehavior;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonobehavior<GameManager>
{
    //because I cannot TAB SceneManager.LoadScene()
    private void SLoad(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    //The Big fonction that change scene, be sure to write the correct scene string name
    public void ChangeScene(PossibleScenes scene)
    {
        switch (scene)
        {
            case PossibleScenes.Menu:
                SLoad("title scene");
                break;
            case PossibleScenes.Credit:
                SLoad("Credit");
                break;
            case PossibleScenes.Ship:
                SLoad("Ship");
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

// All possible reference for button to change the game state
public enum PossibleScenes {
    Menu,
    Credit,
    Vaisseau,
    MiniG1,
    MiniG2,
    MiniG3,
    MiniG4
}
