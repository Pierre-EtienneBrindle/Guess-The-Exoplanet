using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using TMPro;

public class StarPointCounter : MonoBehaviour
{
    private int totalPoints = 0; // Total points collected
    private int starsClicked = 0; // Count of stars clicked
    private int moonsClicked = 0; // Count of moons clicked
    private int planetsClicked = 0; // Count of planets clicked
    
    public TextMeshProUGUI pointsText;
    public void AddPoint(string objectType)
    {
      totalPoints++;
      Debug.Log("Points: " + totalPoints); // Log the current points for testing

        if (objectType.Contains("Star"))
        {
            starsClicked++;
            Debug.Log("Star clicked! Total points: " + totalPoints);
        }
        else if (objectType.Contains("Moon"))
        {
            moonsClicked++;
            Debug.Log("Moon clicked! Total points: " + totalPoints);
        }
        else if (objectType.Contains("Planet"))
        {
            planetsClicked++;
            Debug.Log("Planet clicked! Total points: " + totalPoints);
        }

        UpdatePointsDisplay();
    }
    private void UpdatePointsDisplay()
    {
        if (pointsText != null)
        {
            pointsText.text = "Total Points: " + totalPoints; // Update UI for total points
        }
    }

    public int GetTotalPoints()
    {
        return totalPoints; // Return total points
    }

    public int GetStarsClicked()
    {
        return starsClicked; // Return the number of stars clicked
    }

    public int GetMoonsClicked()
    {
        return moonsClicked; // Return the number of moons clicked
    }

    public int GetPlanetsClicked()
    {
        return planetsClicked; // Return the number of planets clicked
    }

    private void UpdatePointDisplay()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + totalPoints;
        }
    }
}
