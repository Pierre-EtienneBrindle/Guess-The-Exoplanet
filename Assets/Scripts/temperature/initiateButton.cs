using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initiateButton : MonoBehaviour
{
    [SerializeField] private Button b_1;
    [SerializeField] private Button b_2;
    [SerializeField] private Button b_3;
    // Start is called before the first frame update
    void Start()
    {
        b_1.transform.localPosition = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f),0);
        b_2.transform.localPosition = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f),0);
        b_3.transform.localPosition = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f),0);
    }
}
