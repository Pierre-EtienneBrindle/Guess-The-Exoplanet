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

    bool wasSet = false;
    int nbMoonsMax;
    int nbStarsMax;
    int nbPlanetsMax;

    int nbMoonsFound = 0;
    int nbStarsFound = 0;
    int nbPlanetsFound = 0;

    public void SetStartValues(int nbMoons, int nbStars, int nbPlanets)
    {
        if (wasSet)
            return;
        wasSet = true;
        nbMoonsMax = nbMoons;
        nbStarsMax = nbStars;
        nbPlanetsMax = nbPlanets;
        UpdateScoreDisplay();

        List<(Vector2, float)> spawned = new List<(Vector2, float)>(nbPlanets + nbStars + nbMoons);
        for (int i = 0; i < nbStars; i++)
            SpawnAnAstralStructure(StarPrefab, spawned);
        for(int i =  0; i < nbMoons; i++)
            SpawnAnAstralStructure(MoonPrefab, spawned);
        for(int i = 0; i < nbPlanets; i++)
            SpawnAnAstralStructure(PlanetPrefab, spawned);
    }

    void SpawnAnAstralStructure(AstralStructure prefab, List<(Vector2, float)> spawned)
    {
        bool isValide = false;
        Vector2 newPos = Vector2.zero;
        while (!isValide)
        {
            isValide = true;
            float xCord = Random.Range(spawnBounds.min.x + prefab.Radius, spawnBounds.max.x - prefab.Radius);
            float yCord = Random.Range(spawnBounds.min.y + prefab.Radius, spawnBounds.max.y - prefab.Radius);
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
        Destroy(box);
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