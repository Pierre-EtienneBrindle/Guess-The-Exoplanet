using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SingletonBehavior;
using TMPro;
using UnityEngine.UI;
using TMPro.Examples;

public class Exopedia : SingletonMonobehavior<Exopedia>
{
    [SerializeField] TMP_Text text;
    [SerializeField] Button backwardButton;
    [SerializeField] Button forwardButton;
    [SerializeField] Button propertySelectorButton;
    [SerializeField] Button orderingSelectorButton;
    FilterManager filterManager;
    int pageIndex;

    private string[] planetProperties =
    {
        "Number of stars",
        "Number of planets",
        "Radius in Earths",
        "Temperature",
        "Mass in Earths",
        "Orbit duration",
        "Distance from Earth",
        "Transit duration",
    };
    private int planetPropertyIndex;

    private string[] orderings =
    {
        ">",
        "=",
        "<",
    };
    private int orderingIndex;

    private void BackwardButtonClicked()
    {
        pageIndex = System.Math.Max(0, pageIndex - 1);
    }

    private void ForwardButtonClicked()
    {
        pageIndex = System.Math.Min(ExoplanetDataStorer.Instance.Planets.Count - 1, pageIndex + 1);
    }

    private void PropertySelectorButtonClicked()
    {
        planetPropertyIndex = (planetPropertyIndex + 1) % planetProperties.Length;
    }

    private void OrderingSelectorButtonClicked()
    {
        orderingIndex = (orderingIndex + 1) % orderings.Length;
    }

    private void UpdateButtonInteractions()
    {
        backwardButton.interactable = pageIndex > 0;
        forwardButton.interactable = pageIndex < ExoplanetDataStorer.Instance.Planets.Count;
        propertySelectorButton.GetComponentInChildren<TMP_Text>().text = planetProperties[planetPropertyIndex];
        orderingSelectorButton.GetComponentInChildren<TMP_Text>().text = orderings[orderingIndex];
    }

    private void UpdatePage()
    {
        UpdateButtonInteractions();
        text.text = ExoplanetDataStorer.Instance.Planets[pageIndex].PlanetName;
    }

    private void Start()
    {
        pageIndex = 0;
        planetPropertyIndex = 0;
        orderingIndex = 0;
        filterManager = new();
        UpdateButtonInteractions();
        UpdatePage();
        backwardButton.onClick.AddListener(() => { BackwardButtonClicked(); UpdatePage();});
        forwardButton.onClick.AddListener(() => { ForwardButtonClicked(); UpdatePage();});
        propertySelectorButton.onClick.AddListener(() => { PropertySelectorButtonClicked(); UpdateButtonInteractions(); });
        orderingSelectorButton.onClick.AddListener(() => { OrderingSelectorButtonClicked(); UpdateButtonInteractions(); });
    }
}
