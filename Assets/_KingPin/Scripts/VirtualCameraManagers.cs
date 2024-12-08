using System;
using MoreMountains.Tools;
using Unity.Cinemachine;
using UnityEngine;

public class VirtualCameraManagers : MonoBehaviour, MMEventListener<TravelingPhaseStarted>, MMEventListener<TravelingPhaseEnded>, MMEventListener<PuzzlePhaseStarted>, MMEventListener<PuzzlePhaseEnded> // < add your events here>
{
    [SerializeField] private CinemachineCamera topPartCamera;
    [SerializeField] private CinemachineCamera bottomPartCamera;
    private ParallaxBackground_0 topParallax;
    private ParallaxBackground_0 botomParallax;

    private void Start()
    {
        topParallax = topPartCamera.gameObject.GetComponent<ParallaxBackground_0>();
        botomParallax = bottomPartCamera.gameObject.GetComponent<ParallaxBackground_0>();
    }


    public void EnableParallaxMovement()
    {
        topParallax.CameraMove = true;
        botomParallax.CameraMove = true;
    }

    public void DisableParallaxMovement()
    {
        topParallax.CameraMove = false;
        botomParallax.CameraMove = false;
    }

    public void SetTopCameraAsMain()
    {
        topPartCamera.Priority = 1;
        bottomPartCamera.Priority = 0;
    }


    public void SetBottomCameraAsMain()
    {
        topPartCamera.Priority = 0;
        bottomPartCamera.Priority = 1;
    }

    public void OnMMEvent(TravelingPhaseStarted eventType)
    {
        SetBottomCameraAsMain();
        EnableParallaxMovement();
    }
    
    
    public void OnMMEvent(TravelingPhaseEnded eventType)
    {
        DisableParallaxMovement();
    }
    
    
    public void OnMMEvent(PuzzlePhaseStarted eventType)
    {
        SetTopCameraAsMain();
    }
    
    public void OnMMEvent(PuzzlePhaseEnded eventType)
    {
        SetBottomCameraAsMain();
    }

    private void OnEnable()
    {
        this.MMEventStartListening<TravelingPhaseStarted>();
        this.MMEventStartListening<TravelingPhaseEnded>();
        this.MMEventStartListening<PuzzlePhaseStarted>();
        this.MMEventStartListening<PuzzlePhaseEnded>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<TravelingPhaseStarted>();
        this.MMEventStopListening<TravelingPhaseEnded>();
        this.MMEventStopListening<PuzzlePhaseStarted>();
        this.MMEventStopListening<PuzzlePhaseEnded>();
    }



}
