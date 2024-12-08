using System;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class PlayerController : MonoBehaviour,MMEventListener<PlayerTurnStarted>
{

    private PlayerShootingManager shootingManager => GetComponent<PlayerShootingManager>();

    private void EndTurn()
    {
        GameManager.Instance.OnPlayerTurnPhaseComplete();
    }


    private void TakeTurn()
    {
        StartCoroutine(EndTurnAfterDelay());
    }
    
    IEnumerator EndTurnAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);
        shootingManager.Shoot();
        yield return new WaitForSeconds(1);
        EndTurn();
    }

    public void OnMMEvent(PlayerTurnStarted eventType)
    {
        TakeTurn();
    }

    private void OnEnable()
    {
        this.MMEventStartListening<PlayerTurnStarted>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<PlayerTurnStarted>();
    }
}
