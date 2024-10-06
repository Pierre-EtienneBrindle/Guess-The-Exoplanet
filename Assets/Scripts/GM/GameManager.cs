using UnityEngine;
using SingletonBehavior;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonobehavior<GameManager>
{
    bool isPaused = false;
    PossibleScenes currScene = PossibleScenes.Menu;
    ExoplanetData currPlanet = null;

    //because I cannot TAB SceneManager.LoadScene()
    private void SLoad(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    //The Big fonction that change scene, be sure to write the correct scene string name
    public void ChangeScene(PossibleScenes scene)
    {
        currScene = scene;
        switch (scene)
        {
            case PossibleScenes.Menu:
                SLoad("Menu");
                break;
            case PossibleScenes.Credit:
                SLoad("Credit");
                break;
            case PossibleScenes.Ship:
                StartGame();
                break;
            case PossibleScenes.StarDistanceMG:
                SLoad("StarDistanceMG");
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

    void StartGame()
    {
        SLoad("Ship");
        currPlanet = ExoplanetDataStorer.Instance.GetRandomExoplanet();
        //ShipManager.Instance.SetPlanetPicture(generatedPictureFromCode);
    }

    public void TogglePause()
    {
        if (!isPaused && currScene != PossibleScenes.Menu)
            Pause();
        else if(isPaused)
            Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    private void UnPause()
    {
        Time.timeScale = 1;
        isPaused = false;
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
    Ship,
    StarDistanceMG,
    MiniG2,
    MiniG3,
    MiniG4
}