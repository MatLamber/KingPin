using System;
using DG.Tweening;
using MoreMountains.Tools;
using UnityEngine;

public class PuzzlesManager : MonoBehaviour, MMEventListener<PuzzlePhaseStarted>, MMEventListener<PuzzlePhaseEnded> // < add your events here>
{
    [SerializeField] private GameObject currentPuzzle;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = currentPuzzle.transform.localPosition;
    }

    public void ShowCurrentPuzzle()
    {
        currentPuzzle.SetActive(true);
        currentPuzzle.transform.DOLocalMove(Vector3.zero, 1f).SetEase(Ease.OutBack);
    }

    public void HideCurrentPuzzle()
    {
        currentPuzzle.transform.DOLocalMove(originalPosition, 0.3f).SetEase(Ease.InBack).OnComplete(() => currentPuzzle.SetActive(false));
    }
    public void OnMMEvent(PuzzlePhaseStarted eventType)
    {
        ShowCurrentPuzzle();
    }
    
    public void OnMMEvent(PuzzlePhaseEnded eventType)
    {
        HideCurrentPuzzle();
    }

    private void OnEnable()
    {
        this.MMEventStartListening<PuzzlePhaseStarted>();
        this.MMEventStartListening<PuzzlePhaseEnded>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<PuzzlePhaseStarted>();
        this.MMEventStopListening<PuzzlePhaseEnded>();
    }



}
