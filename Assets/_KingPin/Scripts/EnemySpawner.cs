using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, MMEventListener<TravelingPhaseStarted>
{

    [SerializeField] private List<GameObject> enemiesFormation;
    private int currentEnemysFormation;


    IEnumerator SendNextEnemieFormation()
    {
        yield return new WaitForSeconds(1.7f);
        if(currentEnemysFormation < enemiesFormation.Count)
            enemiesFormation[currentEnemysFormation].SetActive(true);
        currentEnemysFormation++;
    }

    public void OnTravelingPhaseStarted()
    {
        StartCoroutine(SendNextEnemieFormation());
    }

    public void OnMMEvent(TravelingPhaseStarted eventType)
    {
        OnTravelingPhaseStarted();
    }

    private void OnEnable()
    {
        this.MMEventStartListening<TravelingPhaseStarted>();
    }
    
    private void OnDisable()
    {
        this.MMEventStopListening<TravelingPhaseStarted>();
    }
}
