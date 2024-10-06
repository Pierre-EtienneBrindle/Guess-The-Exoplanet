using SingletonBehavior;
using UnityEngine;

public class StarDistanceMGManager : SingletonMonobehavior<StarDistanceMGManager>
{
    bool wasSet = false;
    bool wasRead = false;

    [SerializeField] Distance dist;
    [SerializeField] Spawner spawner;
    [SerializeField] Movement movement;

    protected override void Awake()
    {
        base.Awake();
        spawner.enabled = false;
        movement.enabled = false;
    }

    private void OnEnable()
    {
        dist.Done -= OnGameDone;
        dist.Done += OnGameDone;
    }

    private void OnDisable()
    {
        dist.Done -= OnGameDone;
    }

    public void SetDistanceToReach(float distance)
    {
        if (wasSet) 
            return;
        dist.SetDistanceToReach(distance);
        wasSet = true;
        TryStartGame();
    }

    public void OnDoneReading()
    {
        wasRead = true;
        TryStartGame();
    }


    private void TryStartGame()
    {
        if(!wasSet ||  !wasRead) 
            return;
        dist.StartTheTimer();
        spawner.enabled = true;
        movement.enabled = true;
    }

    private void OnGameDone(float dist)
        => GameManager.Instance?.OnDistanceMGDone(dist);
}
