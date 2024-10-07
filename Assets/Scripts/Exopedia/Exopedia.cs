using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using SingletonBehavior;
using TMPro;

public class Exopedia : SingletonMonobehavior<Exopedia>
{
    [SerializeField] TMP_Text planetName;
    [SerializeField] TMP_Text pageCounterText;
    [SerializeField] TMP_Text filterCount;
    [SerializeField] TMP_InputField mesureInput;
    [SerializeField] Image planetImage;
    [SerializeField] Button backwardButton;
    [SerializeField] Button forwardButton;
    [SerializeField] Button propertySelectorButton;
    [SerializeField] Button orderingSelectorButton;
    [SerializeField] Button confirmSelectionButton;
    [SerializeField] Button addFilterButton;
    [SerializeField] Button removeFilterButton;

    FilterManager filterManager;
    List<ExoplanetData> filteredPlanets;
    int pageIndex;


    private (string str, FilterType val)[] planetProperties =
    {
        ("Number of stars", FilterType.NbStars),
        ("Number of planets", FilterType.NbPlanet),
        ("Radius in Earths", FilterType.RadiusInEarth),
        ("Temperature in Kelvin", FilterType.Temperature),
        ("Mass in Earths", FilterType.MassInEarth),
        ("Orbit duration in days", FilterType.OrbitDurationInDays),
        ("Distance from Earth in pc", FilterType.DistanceFromEarth),
        ("Transit duration in hours", FilterType.TransitDuration),
    };
    private int planetPropertyIndex;

    private (string str, FilterOrdering val)[] orderings =
    {
        (">", FilterOrdering.Greater),
        ("=", FilterOrdering.Equal),
        ("<", FilterOrdering.Lesser),
    };
    private int orderingIndex;

    private void BackwardButtonClicked()
    {
        pageIndex = System.Math.Max(0, pageIndex - 1);
    }

    private void ForwardButtonClicked()
    {
        pageIndex = System.Math.Min( filteredPlanets.Count - 1, pageIndex + 1);
    }

    private void PropertySelectorButtonClicked()
    {
        planetPropertyIndex = (planetPropertyIndex + 1) % planetProperties.Length;
    }

    private void AddFilterButtonClicked()
    {
        if (float.TryParse(mesureInput.text, out float value))
        {
            filterManager.Filters.Add(new Filter(
                    planetProperties[planetPropertyIndex].val,
                    orderings[orderingIndex].val,
                    value
                ));
            RecomputeFilters();
        }
    }

    private void RemoveFilterButtonClicked()
    {
        if (filterManager.Filters.Count != 0)
        {
            filterManager.Filters.RemoveAt(filterManager.Filters.Count - 1);
            RecomputeFilters();
        }
    }

    private void ConfirmSelectionButtonClicked()
    {
        // TODO: Dire au gamemanager qu'une planette a été choisie.
    }
    private void RecomputeFilters()
    {
        filteredPlanets = filterManager.GetFilteredPlanets();
        UpdatePageCounterText();
        UpdateFilterCount();
        UpdateButtonInteractions();
        UpdatePage();
    }

    private void UpdatePageCounterText()
    {
        StringBuilder sb = new("Page ", 128);
        sb.Append((pageIndex + 1).ToString());
        sb.Append(" of ");
        sb.Append(filteredPlanets.Count.ToString());

        pageCounterText.text = sb.ToString();
    }
    
    private void UpdateFilterCount()
    {
        StringBuilder sb = new("Currently applying ");
        sb.Append(filterManager.Filters.Count.ToString());
        sb.Append(" filters.");

        filterCount.text = sb.ToString();
    }
    private void OrderingSelectorButtonClicked()
    {
        orderingIndex = (orderingIndex + 1) % orderings.Length;
    }

    private void UpdateButtonInteractions()
    {
        backwardButton.interactable = pageIndex > 0 && filteredPlanets.Count != 0;
        forwardButton.interactable = pageIndex < filteredPlanets.Count && filteredPlanets.Count != 0;
        propertySelectorButton.GetComponentInChildren<TMP_Text>().text = planetProperties[planetPropertyIndex].str;
        orderingSelectorButton.GetComponentInChildren<TMP_Text>().text = orderings[orderingIndex].str;
        UpdatePageCounterText();
    }

    private void UpdatePage()
    {
        UpdateButtonInteractions();
        if (filteredPlanets.Count > 0)
        {
            planetName.text = filteredPlanets[pageIndex].PlanetName;
            planetImage.sprite = ExoplanetSpriteGenerator.Instance.GenerateSprite(filteredPlanets[pageIndex]);
        } else
        {
            planetName.text = "No planets";
        }
    }

    private void Start()
    {
        pageIndex = 0;
        planetPropertyIndex = 0;
        orderingIndex = 0;
        filterManager = new();
        filteredPlanets = ExoplanetDataStorer.Instance.Planets;
        UpdateButtonInteractions();
        UpdatePage();
        backwardButton.onClick.AddListener(() => { BackwardButtonClicked(); UpdatePage();});
        forwardButton.onClick.AddListener(() => { ForwardButtonClicked(); UpdatePage();});
        propertySelectorButton.onClick.AddListener(() => { PropertySelectorButtonClicked(); UpdateButtonInteractions(); });
        orderingSelectorButton.onClick.AddListener(() => { OrderingSelectorButtonClicked(); UpdateButtonInteractions(); });
        confirmSelectionButton.onClick.AddListener(() => { ConfirmSelectionButtonClicked(); });
        addFilterButton.onClick.AddListener(() => { AddFilterButtonClicked(); });
        removeFilterButton.onClick.AddListener(() => { RemoveFilterButtonClicked(); });
    }
}
