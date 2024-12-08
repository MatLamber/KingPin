using System;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Tools;

public class MoveOnClick : MonoBehaviour, MMEventListener<PuzzleSolved>
{
   
    [SerializeField] private Vector3 finalPosition;

    // Tiempo que tarda en completar el movimiento
    [SerializeField] private float moveDuration = 1f;

    [SerializeField] private bool isRequiredPin;

    // Indica si el objeto ya está en movimiento
    private bool isMoving = false;

    // Método que se activa cuando se hace click en el objeto
    private void OnMouseDown()
    {
        // Solo ejecuta la animación si no está ya en movimiento
        if (!isMoving)
        {
            isMoving = true;
            if(isRequiredPin)
                PinMovement.Trigger();
            MoveObject();
        }
    }

    // Método que realiza el movimiento
    private void MoveObject()
    {
        transform.DOLocalMove(finalPosition, moveDuration);
    }

    
    public void OnMMEvent(PuzzleSolved eventType)
    {
        isMoving = true;
    }
    
    private void OnEnable()
    {
        this.MMEventStartListening<PuzzleSolved>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<PuzzleSolved>();
        isMoving = false;
    }


}