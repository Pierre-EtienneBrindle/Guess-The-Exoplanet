using UnityEngine;

public class ScrollingSpace : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    Transform[] childArray = new Transform[2];
    readonly int TELEPORT_POS = 200;

    /// <summary>
    /// On initialise les panneaux � la bonne position, rotation et �chelle.
    /// Pour la position : on place les panneaux un � c�t� de l'autre
    /// Pour la rotation : on r�initialise la rotation
    /// Pour l'�chelle : on utilise une proportion de la taille de l'�cran
    /// </summary>
    private void Start()
    {

        int i = 0;
        foreach (Transform child in gameObject.transform)
        {
            childArray[i++] = child;
        }

        childArray[0].transform.position = new Vector3(0, TELEPORT_POS,Camera.main.transform.position.z + 10);
        childArray[1].transform.position = new Vector3(0, 0, Camera.main.transform.position.z + 10);
    }

    /// <summary>
    /// On fait glisser les panneaux vers la gauche et on s'assure qu'aucun espace vide s'affiche � l'�cran
    /// </summary>
    void Update()
    {
        for (int i = 0; i <= 1; ++i)
        {
            if (IsOutOfScreen(childArray[i]))
            {
                childArray[0].transform.position = new(0, TELEPORT_POS,gameObject.transform.position.z + 10);
                childArray[1].transform.position = new(0,0, gameObject.transform.position.z + 10);
            }
            childArray[i].transform.Translate(speed * Time.deltaTime *Vector3.down);
        }
    }

    /// <summary>
    /// IsOutOfScreen retourne vrai si le panneau est sorti de l'�cran par la gauche, faux sinon.
    /// </summary>
    bool IsOutOfScreen(Transform childTransform)
        => childTransform.position.y <= -TELEPORT_POS;
}