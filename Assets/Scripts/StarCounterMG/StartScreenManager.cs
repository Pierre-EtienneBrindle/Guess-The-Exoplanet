using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] Button startButton;
    [SerializeField] StarCounterMGManager starCounterMGManager;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(CloseInstructionsAndStartGame);
    }
    void CloseInstructionsAndStartGame()
    {
        instructionsPanel.SetActive(false);

        starCounterMGManager.OnRead();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
