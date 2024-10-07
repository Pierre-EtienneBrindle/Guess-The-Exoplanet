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
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject sphere1;
    [SerializeField] private GameObject sphere2;
    [SerializeField] private GameObject sphere3;

    [SerializeField] private GameManager gameManager;
    
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
            if(transform.rotation.eulerAngles.z >= 80 && transform.rotation.eulerAngles.z <= 102)
            {
                //mettre le texte infrarouge en vert
                txt_infrarouge.color = Color.green;
              
                Image img = parent.GetComponent<Image>();
            
                sphere1.GetComponent<Image>().color = Random.ColorHSV();
                sphere2.GetComponent<Image>().color = Random.ColorHSV();
                sphere3.GetComponent<Image>().color = Random.ColorHSV();

                sphere1.SetActive(true);
                sphere2.SetActive(true);
                sphere3.SetActive(true);
                
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
