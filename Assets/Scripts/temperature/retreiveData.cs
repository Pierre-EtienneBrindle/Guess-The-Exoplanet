using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class retreiveData : MonoBehaviour
{
    float temperature;
    [SerializeField] private Button b_1;
    [SerializeField] private Button b_2;
    [SerializeField] private Button b_3;

    private bool b_b_1;
    private bool b_b_2;
    private bool b_b_3;

    [SerializeField] private GameObject sphere1;
    [SerializeField] private GameObject sphere2;
    [SerializeField] private GameObject sphere3;

    [SerializeField] private GameObject tempDisplay;
    // Start is called before the first frame update
    void Start()
    {
        b_b_1 = false;
        b_b_2 = false;
        b_b_3 = false;
        b_1.onClick.AddListener(() => { b_b_1 = true;  });
        b_2.onClick.AddListener(() => { b_b_2 = true; });
        b_3.onClick.AddListener(() => { b_b_3 = true; Debug.Log("test"); });
    }

    // Update is called once per frame
    void Update()
    {
        if(b_b_1)
        {
            b_1.enabled = false;
            sphere1.SetActive(false);
        }
        if(b_b_2)
        {
            b_2.enabled = false;
            sphere2.SetActive(false);
        }
        if(b_b_3)
        {
            b_3.enabled = false;
            sphere3.SetActive(false);
        }
        if(b_b_1 && b_b_2 && b_b_3)
        {
            //mission reussi
            temperature = 130;
            tempDisplay.GetComponent<TMP_Text>().SetText("the temperature is " + temperature + " K");
            tempDisplay.SetActive(true);
        }
    }

    public void SetTemperature(float value) //function called when the game is started 
        => temperature = value;
}
