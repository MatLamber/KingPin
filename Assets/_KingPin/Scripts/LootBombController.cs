using System;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

public class LootBombController : MonoBehaviour
{
    [SerializeField] private MMF_Player igniteFeedBack;
    [SerializeField] private float scaleMultiplier;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject explosion;
    [SerializeField] private ParticleSystem explosionParticle;
    private Vector3 originalScale;



    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnIgnite()
    {
        igniteFeedBack?.PlayFeedbacks();
        transform.DOScale(originalScale * scaleMultiplier, 2f).OnComplete(() =>
        {
            bomb.SetActive(false);
            explosionParticle.Play();
            explosion.SetActive(true);
        });
    }
    
    
    

    
}
