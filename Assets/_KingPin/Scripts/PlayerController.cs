using System;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class PlayerController : MonoBehaviour,MMEventListener<PlayerTurnStarted>
{

    private PlayerShootingManager shootingManager => GetComponent<PlayerShootingManager>();
    private int numberOfTurns = 2;

    private void EndTurn()
    {
        GameManager.Instance.OnPlayerTurnPhaseComplete();
    }


    private void TakeTurn()
    {
        StartCoroutine(TakeMultipleTurns());
    }

    
    private IEnumerator TakeMultipleTurns()
    {
        for (int i = 0; i < numberOfTurns; i++)
        {
            StartCoroutine(Shoot());
            yield return new WaitForSeconds(0.2f); // Asegurarse de espaciar bien las acciones
        }

        // Llamar a la corrutina después de la última iteración
        StartCoroutine(EndTurnAfterDelay());
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.2f);
        shootingManager.Shoot();
    }
    
    IEnumerator EndTurnAfterDelay()
    {
        yield return new WaitForSeconds(1);
        EndTurn();
    }

    public void OnDeath()
    {
        TriggerDeathEvent();
    }

    public void TriggerDeathEvent()
    {
        PlayerDeath.Trigger();
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
