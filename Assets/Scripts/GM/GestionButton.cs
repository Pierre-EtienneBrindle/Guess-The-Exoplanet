using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] PossibleScenes sceneToLoad;

    public void ChangeScene() => GameManager.Instance.ChangeScene(sceneToLoad);
}