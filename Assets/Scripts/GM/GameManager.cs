using UnityEngine;
using SingletonBehavior;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : SingletonMonobehavior<GameManager>
{
    bool isPaused = false;
    PossibleScenes currScene = PossibleScenes.Menu;
    ExoplanetData currPlanet = null;
    bool hasSuceededCounterMinigame;

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
            case PossibleScenes.StarCounterMG:
                StartCoroutine(StartStarCounterMinigame());
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
        Debug.Log(currPlanet.PlanetName);
        //ShipManager.Instance.SetPlanetPicture(generatedPictureFromCode);
    }

    IEnumerator StartStarCounterMinigame()
    {
        if (hasSuceededCounterMinigame ||((currPlanet.NbMoon == null || currPlanet.NbMoon == 0) &&
            (currPlanet.NbStars == null || currPlanet.NbStars == 0) &&
            (currPlanet.NbPlanet == null || currPlanet.NbPlanet == 0)))
            yield break;
        SLoad("StarCounterMG");
        yield return null;
        yield return null;
        yield return null;
        StarCounterMGManager.Instance.SetStartValues(currPlanet.NbMoon == null ? 0 : currPlanet.NbMoon.Value, 
                                                    currPlanet.NbStars == null ? 0 : currPlanet.NbStars.Value, 
                                                    currPlanet.NbPlanet == null ? 0 : currPlanet.NbPlanet.Value);
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

    public void OnStarCounterMGSucess()
    {
        hasSuceededCounterMinigame = true;
    }
}

// All possible reference for button to change the game state
public enum PossibleScenes {
    Menu,
    Credit,
    Ship,
    StarDistanceMG,
    StarCounterMG,
    MiniG3,
    MiniG4
}