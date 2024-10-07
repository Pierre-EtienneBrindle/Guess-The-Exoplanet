using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class retreiveData : MonoBehaviour
{
    bool finished = false;
    float timer = 2.0f;
    float timertemp = 0.0f;
    float temperature;
    int failedAttemp = 0;
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
        b_1.onClick.AddListener(() => { b_b_1 = true; });
        b_2.onClick.AddListener(() => { b_b_2 = true; });
        b_3.onClick.AddListener(() => { b_b_3 = true; });
    }

    // Update is called once per frame
    void Update()
    {
        if(timertemp < timer)
        {
            timertemp += Time.deltaTime;
        }
        else if(Input.GetMouseButton(0))
        {
            failedAttemp += 1;
            timertemp = 0.0f;
        }

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
        if(b_b_1 && b_b_2 && b_b_3 && !finished)
        {
            finished = true;
            //mission reussi
            float mintemp;
            float maxtemp;
            
                mintemp = temperature - Random.Range(0.0f, failedAttemp);
            Mathf.Round(mintemp);
            maxtemp = temperature + Random.Range(0.0f, failedAttemp);
            Mathf.Round(maxtemp);
            tempDisplay.GetComponent<TMP_Text>().SetText("the temperature is at minimum " + mintemp + " K and the maximum is " + maxtemp + " K");
            GameManager.Instance.OnTemperatureMGDone(mintemp, maxtemp);
            tempDisplay.SetActive(true);
        }
    }

    public void SetTemperature(float value) //function called when the game is started 
        => temperature = value;
}
