using System;
using DG.Tweening;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void OnEnable()
    {
        MoveToTarget();
    }


    public void MoveToTarget()
    {
        transform.SetParent(target);
        transform.DOLocalMove(Vector3.zero, 0.5f);
    }
}
