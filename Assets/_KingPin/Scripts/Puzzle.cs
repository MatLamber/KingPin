using System.Collections;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.Serialization;

public class Puzzle : MonoBehaviour, MMEventListener<LootPoolEmptied>
{
    [SerializeField] private int lootPools;
    private Coroutine countdownCoroutine;
    private const float countdownTime = 10f;
    private bool puzzleSolved = false; // Track if the puzzle is already solved
    
    private void EndPuzzle()
    {
        if (puzzleSolved)
        {
            return; // Exit if already resolved
        }

        puzzleSolved = true; // Mark as solved
        Debug.Log("Puzzle Solved");
        PuzzleSolved.Trigger();
        StartCoroutine(EndPhase());
    }
    

    IEnumerator EndPhase()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.OnPuzzlePhaseComplete();
    }
    
    public void OnLootPoolEmptied()
    {
        lootPools--;
        if(lootPools == 0)
            EndPuzzle();
    }

    
    public void OnMMEvent(LootPoolEmptied eventType)
    {
        OnLootPoolEmptied();
    }

    private void OnEnable()
    {
        this.MMEventStartListening<LootPoolEmptied>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<LootPoolEmptied>();
    }


}