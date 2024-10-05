using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SingletonBehavior;
using UnityEngine.SceneManager;

public class GameManager : SingletonMonobehavior<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }


    public void LoadMainMenu()
    {
        LoadScene("Title scene");
    }

    public void LoadGameScene();
    {
        LoadScene("Game");
        
    }
}
