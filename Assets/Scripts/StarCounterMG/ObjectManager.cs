using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public string objectTag = "ClickableObject"; // Tag to find objects
    public List<GameObject> objects; // List to store your circle objects
    private StarPointCounter starPointCounter; // Reference to the StarPointCounter
    void Start()
    {
        
        // Find all objects with the specified tag and add them to the list
        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag(objectTag));

        foreach (GameObject obj in objects)
       {
         obj.AddComponent<Pointer>();
       }

        // Optional: Log the number of objects found
        Debug.Log(objects.Count + " objects found with the tag: " + objectTag);

        starPointCounter = FindObjectOfType<StarPointCounter>();
    }

    void Update()
    {
        
        // Check for clicks on each object in the list
        foreach (GameObject obj in objects)
        {
            Pointer pointerScript = obj.GetComponent<Pointer>(); // Get the Pointer script from the object
            if (pointerScript != null)
            {
                // Check for click and notify the StarPointCounter
                pointerScript.CheckForClick(starPointCounter); // Pass starPointCounter to the CheckForClick method
                
            }
        }
    }
}
