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
public class UIManager : MMSingleton<UIManager>, MMEventListener<UpgradePhaseStarted>, MMEventListener<PlayerDeath>
{
    /// the main canvas
    [Tooltip("the main canvas")] public Canvas MainCanvas;
    

    [SerializeField] private GameObject upgradesPanel;
    private Vector3 upgradesPanelOriginalPosition;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

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
    
    
    public void ShowLosePanel()
    {
        StartCoroutine(ShowLosePanelCo());
    }
    
    public void ShowWinPanel()
    {
        StartCoroutine(ShowWinPanelCo());
    }
    
    IEnumerator ShowWinPanelCo()
    {
        yield return new WaitForSeconds(1f);
        winPanel.SetActive(true);
    }
    IEnumerator ShowLosePanelCo()
    {
        yield return new WaitForSeconds(1f);
        losePanel.SetActive(true);
    }

    public void OnPlayerDeath()
    {
        ShowLosePanel();
    }
    public void OnMMEvent(PlayerDeath eventType)
    {
        OnPlayerDeath();
    }

    private void OnEnable()
    {
        this.MMEventStartListening<UpgradePhaseStarted>();
        this.MMEventStartListening<PlayerDeath>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<UpgradePhaseStarted>();
        this.MMEventStopListening<PlayerDeath>();
    }


}