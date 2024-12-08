using System;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class Puzzle : MonoBehaviour, MMEventListener<PinMovement>
{
    [SerializeField] private int requieredMovementsToWin;
    
    public void OnPinMovement()
    {
        requieredMovementsToWin--;
        if (requieredMovementsToWin == 0)
        {
            Debug.Log("Puzzle Solved");
            PuzzleSolved.Trigger();
            StartCoroutine(EndPhase());
        }
    }


    IEnumerator EndPhase()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.OnPuzzlePhaseComplete();
    }
    public void OnMMEvent(PinMovement eventType)
    {
        OnPinMovement();
    }
    
    private void OnEnable()
    {
        this.MMEventStartListening<PinMovement>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<PinMovement>();
    }
}
