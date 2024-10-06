using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.Windows;
using TMPro.Examples;

public class Pointer : MonoBehaviour
{
    public float radius = 1.0f; // Set the radius of your circle
    private bool isClicked = false; // Flag to check if the circle has been clicked
    

    // Update is called once per frame
    public void CheckForClick(StarPointCounter starPointCounter)
    {
        if (UnityEngine.Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition); // Get mouse position in world space
            Vector2 circleCenter = transform.position; // Get the circle's position

            // Calculate the distance between the mouse position and the circle's center
            float distance = Vector2.Distance(mousePosition, circleCenter);

            

            // Check if the click is within the circle's radius
            if (distance <= radius && !isClicked)
            {
                string objectType = gameObject.tag;
                

                starPointCounter.AddPoint(objectType); // Call to add point to the StarPointCounter
                isClicked = true; //the circle has been clicked 

                
                
            }
            
        }
    } 
}