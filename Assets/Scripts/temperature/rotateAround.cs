using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class rotateAround : MonoBehaviour
{
    [SerializeField] private float degrees;
    [SerializeField] private Button b_stop;
    private float wait;
    private float waitTemp;
    private bool rotating;

    [SerializeField] private GameObject Infrarouge;

    private TMP_Text txt_infrarouge;

    // Start is called before the first frame update
    void Start()
    {
        degrees = Random.Range(0.05f,0.8f);
        b_stop.onClick.AddListener(() => { stopRotation(); });
        rotating = true;
        wait = 1.0f;
        waitTemp = 0.0f;
        txt_infrarouge = Infrarouge.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating)
        {
            if (transform.rotation.eulerAngles.z >= 180)
            {
                degrees = -1 * degrees;
            }
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.forward * degrees);
        }
        else
        {
            if(transform.rotation.eulerAngles.z >= 83 && transform.rotation.eulerAngles.z <= 97)
            {
                //mettre le texte infrarouge en vert
                txt_infrarouge.color = Color.green;
            }
            else
            {
                waitTemp += Time.deltaTime;
                if( waitTemp >= wait)
                {
                    waitTemp = 0.0f;
                    rotating = true;
                }
            }
        }
    }


    void stopRotation()
    {
        rotating = false;
    }
}
