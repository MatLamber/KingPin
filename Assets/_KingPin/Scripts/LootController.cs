using System;
using DG.Tweening;
using UnityEngine;

public class LootController : MonoBehaviour
{
    private string moneyCollectorTag = "MoneyCollector";
    private Vector3 originalScale;
    private Rigidbody rigidbody;

    private void Start()
    {
        originalScale = transform.localScale;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(moneyCollectorTag))
        {
            rigidbody.isKinematic = true;
            GoToTarget(other.transform.position);
            Shrink();
        }
  
    }

    public void Shrink ()
    {
        transform.DOScale(Vector3.zero, 0.2f).OnComplete((() => gameObject.SetActive(false))).SetDelay(0.1f);
    }

    public void GoToTarget(Vector3 targetPosion)
    {
        transform.DOMove(targetPosion, 0.3f);
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
        rigidbody.isKinematic = false;
    }
}