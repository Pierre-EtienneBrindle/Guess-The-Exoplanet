using SingletonBehavior;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarCounterMGManager : SingletonMonobehavior<StarCounterMGManager>
{
    Bounds spawnBounds;
    [SerializeField] AstralStructure StarPrefab;
    [SerializeField] AstralStructure MoonPrefab;
    [SerializeField] AstralStructure PlanetPrefab;
    [SerializeField] TMP_Text totalPointsText; // Reference to your TextMeshPro text component for total points
    [SerializeField] TMP_Text starsText; // Reference to your TextMeshPro text component for stars clicked
    [SerializeField] TMP_Text moonsText; // Reference to your TextMeshPro text component for moons clicked
    [SerializeField] TMP_Text planetsText; // Reference to your TextMeshPro text component for planets clicked


    [SerializeField] TMP_Text timerText;
    [SerializeField] float gameDuration = 60f; // duartion of the game. 
    
    bool wasSet = false;
    bool isDoneReading = false;
    int nbMoonsMax;
    int nbStarsMax;
    int nbPlanetsMax;

    int nbMoonsFound = 0;
    int nbStarsFound = 0;
    int nbPlanetsFound = 0;

    float timeRemaining; // timer variable 

   
    public void SetStartValues(int nbMoons, int nbStars, int nbPlanets)
    {
        Debug.Log($"M : {nbMoons}  S : {nbStars}  P : {nbPlanets}");
        if (wasSet )
            return;
        wasSet = true;
        nbMoonsMax = nbMoons;
        nbStarsMax = nbStars;
        nbPlanetsMax = nbPlanets;
        UpdateScoreDisplay();

        timeRemaining = gameDuration; //Initialize timer 

        List<(Vector2, float)> spawned = new List<(Vector2, float)>(nbPlanets + nbStars + nbMoons);
        for (int i = 0; i < nbStars; i++)
            SpawnAnAstralStructure(StarPrefab, spawned);
        for(int i =  0; i < nbMoons; i++)
            SpawnAnAstralStructure(MoonPrefab, spawned);
        for(int i = 0; i < nbPlanets; i++)
            SpawnAnAstralStructure(PlanetPrefab, spawned);
    }

    public void OnRead()
    {
        isDoneReading = true;
    }
    
    void Update()
    {
        if (isDoneReading && wasSet && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(); 

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                EndGame(); 
            }
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = $"Time Left: {Mathf.Ceil(timeRemaining)}s";
    }

    void EndGame()
    {
        Debug.Log("Time's up! Game Over.");
        GameManager.Instance?.OnStarCounterMGSucess();
        GameManager.Instance?.ChangeScene(PossibleScenes.Ship);
    }



    void SpawnAnAstralStructure(AstralStructure prefab, List<(Vector2, float)> spawned)
    {
        bool isValide = false;
        Vector2 newPos = Vector2.zero;
        const int MAX_NB_TRY = 10000;
        for(int i = 0; (i <= MAX_NB_TRY) && !isValide; i++)
        {
            isValide = true;
            float xCord = Random.Range(spawnBounds.min.x + prefab.Radius *1.1f, spawnBounds.max.x - prefab.Radius*1.1f);
            float yCord = Random.Range(spawnBounds.min.y + prefab.Radius*1.1f, spawnBounds.max.y - prefab.Radius*1.1f);
            newPos = new Vector2(xCord, yCord);
            foreach ((Vector2, float) elem in spawned)
            {
                float minDist = prefab.Radius + elem.Item2;
                if ((elem.Item1 - newPos).sqrMagnitude < minDist * minDist)
                {
                    isValide = false;
                    break;
                }
            }
        }
        spawned.Add((newPos, prefab.Radius));
        Instantiate(prefab, newPos, Quaternion.identity);
    }

    protected override void Awake()
    {
        base.Awake();
        UpdateScoreDisplay();
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        spawnBounds = box.bounds;   
    }

    public void OnAstralObjectDetected(AstralStructureType type)
    {
        if (type == AstralStructureType.Moon)
            ++nbMoonsFound;
        else if(type == AstralStructureType.Star)
            ++nbStarsFound;
        else if(type== AstralStructureType.Planet)
            ++nbPlanetsFound;
        UpdateScoreDisplay();

        if(nbMoonsFound >= nbMoonsMax && nbPlanetsFound == nbPlanetsMax && nbStarsFound == nbStarsMax)
        {
            EndGame();
        }
    }

    private void UpdateScoreDisplay()
    {
        totalPointsText.text = $"Total Points: {nbStarsFound + nbMoonsFound + nbPlanetsFound}";// Display total points
        starsText.text = $"Stars Clicked: {nbStarsFound}";// Display stars clicked
        moonsText.text = $"Moons Clicked: {nbMoonsFound}"; // Display moons clicked
        planetsText.text = $"Planets Clicked: {nbPlanetsFound}"; // Display planets clicked
    }
}