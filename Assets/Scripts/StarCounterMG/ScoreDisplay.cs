using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ScoreDisplay : MonoBehaviour
{
    public StarPointCounter starPointCounter;
    public TextMeshProUGUI totalPointsText; // Reference to your TextMeshPro text component for total points
    public TextMeshProUGUI starsText; // Reference to your TextMeshPro text component for stars clicked
    public TextMeshProUGUI moonsText; // Reference to your TextMeshPro text component for moons clicked
    public TextMeshProUGUI planetsText; // Reference to your TextMeshPro text component for planets clicked
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (starPointCounter != null) 
        {
            UpdateScoreDisplay();
        }
    }
    private void UpdateScoreDisplay()
    {
        totalPointsText.text = "Total Points: " + starPointCounter.GetTotalPoints().ToString(); // Display total points
        starsText.text = "Stars Clicked: " + starPointCounter.GetStarsClicked().ToString(); // Display stars clicked
        moonsText.text = "Moons Clicked: " + starPointCounter.GetMoonsClicked().ToString(); // Display moons clicked
        planetsText.text = "Planets Clicked: " + starPointCounter.GetPlanetsClicked().ToString(); // Display planets clicked
    }
}
