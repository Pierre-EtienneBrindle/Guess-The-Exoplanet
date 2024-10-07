using UnityEngine;
using SingletonBehavior;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : SingletonMonobehavior<GameManager>
{
    bool isPaused = false;
    PossibleScenes currScene = PossibleScenes.Menu;
    ExoplanetData currPlanet = null;

    bool hasDoneCounterMinigame = false;
    int nbMoonFound = 0;
    int nbStarsFound = 0;
    int nbPlanetsFound = 0;

    bool hasDoneTemperatureReading = false;
    float minTemp = float.MaxValue;
    float maxTemp = float.MinValue;

    bool hasDoneDistanceReading = false;
    float distanceMeasured = float.MaxValue;

    bool hasDoneMassReading = false;
    float aproximateMass = float.MinValue;


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
                StartCoroutine(StartDistanceMG());
                break;
            case PossibleScenes.StarCounterMG:
                StartCoroutine(StartStarCounterMinigame());
                break;
            case PossibleScenes.TemperatureMG:
                StartCoroutine(StartTemperatureMinigame());
                break;
            case PossibleScenes.GravityMG:
                StartCoroutine(StartMassMG());
                break;
            case PossibleScenes.Wiki:
                SLoad("Exopedia");
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

    IEnumerator StartDistanceMG()
    {
        if(hasDoneDistanceReading || currPlanet.DistanceFromEarth == null)
            yield break;
        SLoad("StarDistanceMG");
        yield return null;
        yield return null;
        yield return null;
        StarDistanceMGManager.Instance.SetDistanceToReach(currPlanet.DistanceFromEarth.Value);
    }

    IEnumerator StartStarCounterMinigame()
    {
        if (hasDoneCounterMinigame ||((currPlanet.NbMoon == null || currPlanet.NbMoon == 0) &&
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

    IEnumerator StartTemperatureMinigame()
    {
        if (currPlanet.Temperature == null || hasDoneTemperatureReading)
            yield break;

        SLoad("temperature scene");
        yield return null;
        yield return null; 
        yield return null;
        GameObject.FindWithTag("DataReceiver").GetComponent<retreiveData>().SetTemperature(currPlanet.Temperature.Value);
    }

    IEnumerator StartMassMG()
    {
        if(hasDoneMassReading || currPlanet.MassInEarth == null)
            yield break;
        SLoad("PlanetMasse");
        yield return null;
        yield return null; 
        yield return null;
    }

    public void OnStarCounterMGSucess(int nbMoon, int nbStars, int nbPlanets)
    {
        if (hasDoneCounterMinigame)
            return;
        hasDoneCounterMinigame = true;
        nbMoonFound = nbMoon;
        nbStarsFound = nbStars;
        nbPlanetsFound = nbPlanets;
        SLoad("Ship");
    }

    public void OnTemperatureMGDone(float min, float max)
    {
        if (hasDoneTemperatureReading)
            return;
        hasDoneTemperatureReading = true;
        minTemp = min;
        maxTemp = max;
        SLoad("Ship");
    }

    public void OnDistanceMGDone(float dist)
    {
        if (hasDoneDistanceReading)
            return;
        hasDoneDistanceReading = true;
        distanceMeasured = dist;
        SLoad("Ship");  
    }

    public void OnMassMGDone(float mass)
    {
        if(hasDoneMassReading)
            return;
        hasDoneMassReading = true;
        aproximateMass = mass;
        SLoad("Ship");
    }
}

// All possible reference for button to change the game state
public enum PossibleScenes {
    Menu,
    Credit,
    Ship,
    StarDistanceMG,
    StarCounterMG,
    TemperatureMG,
    GravityMG,
    Wiki
}