using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Handles all GUI effects and changes
/// </summary>
[AddComponentMenu("TopDown Engine/Managers/GUI Manager")]
public class UIManager : MMSingleton<UIManager>, MMEventListener<UpgradePhaseStarted>
{
    /// the main canvas
    [Tooltip("the main canvas")] public Canvas MainCanvas;
    

    [SerializeField] private GameObject upgradesPanel;
    private Vector3 upgradesPanelOriginalPosition;

    /// <summary>
    /// Statics initialization to support enter play modes
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    protected static void InitializeStatics()
    {
        _instance = null;
    }

    /// <summary>
    /// Initialization
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        Inicialization();
    }


    private void Inicialization()
    {
        upgradesPanelOriginalPosition = upgradesPanel.transform.localPosition;
    }

    public void ShowUpgradesPanel()
    {
        upgradesPanel.SetActive(true);
        upgradesPanel.transform.DOLocalMoveY(0, 0.3f).SetEase(Ease.OutBack);
    }
    
    public void HideUpgradesPanel()
    {
        upgradesPanel.transform.DOLocalMoveY(upgradesPanelOriginalPosition.y, 0.3f).SetEase(Ease.InBack).OnComplete(() => upgradesPanel.SetActive(false));
    }

    public void SelectUpgradeOption()
    {
        
        HideUpgradesPanel();
        UpgradeOptionSelected.Trigger();
        GameManager.Instance.OnUpgradePhaseComplete();
    }


    public void OnUpgradePhaseStarted()
    {
        ShowUpgradesPanel();
    }
    public void OnMMEvent(UpgradePhaseStarted eventType)
    {
        OnUpgradePhaseStarted();
    }


    private void OnEnable()
    {
        this.MMEventStartListening<UpgradePhaseStarted>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<UpgradePhaseStarted>();
    }
}