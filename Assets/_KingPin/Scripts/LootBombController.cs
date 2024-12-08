using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

public class LootBombController : MonoBehaviour
{
    [SerializeField] private MMF_Player igniteFeedBack;
    [SerializeField] private float scaleMultiplier;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject explosion2D;
    [SerializeField] private ParticleSystem explosionParticle;

    [SerializeField] private float graceTime = 3.0f; // Tiempo de gracia después de registrar los colliders iniciales

    private HashSet<Collider> initialColliders = new HashSet<Collider>();
    private bool isIgniteMode = false;
    private bool checkForNewCollisions = false;
    private float elapsedTime = 0.0f;

    private void Start()
    {
        RegisterInitialCollisions();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= graceTime && !checkForNewCollisions)
        {
            checkForNewCollisions = true; // Activar la verificación de nuevas colisiones después del tiempo de gracia
            Debug.Log("Tiempo de gracia terminado. Listo para verificar nuevas colisiones.");
        }
    }

    private void RegisterInitialCollisions()
    {
        Collider[]
            colliders = Physics.OverlapSphere(transform.position, 0.5f); // Asume un radio pequeño alrededor del objeto
        foreach (Collider collider in colliders)
        {
            initialColliders.Add(collider);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (checkForNewCollisions && !initialColliders.Contains(collision.collider) && !isIgniteMode)
        {
            OnIgnite();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MoneyCollector"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            DOTween.Kill(transform);
            transform.position = other.transform.position; 
            bomb.SetActive(false);
            explosionParticle.Play();
            explosion2D.SetActive(true);
            StartCoroutine(DisableBomb());

        }
    }

    IEnumerator DisableBomb()
    {
        yield return new WaitForSeconds(0.1f);
        explosion2D.SetActive(false);
    }

    private void OnIgnite()
    {
        isIgniteMode = true;
        Debug.Log("La bomba estalla.");
        igniteFeedBack?.PlayFeedbacks();
        transform.DOScale(transform.localScale * scaleMultiplier, 2f).OnComplete(() =>
        {
            bomb.SetActive(false);
            explosionParticle.Play();
            explosion.SetActive(true);
        });
        // Opcional: Desactiva el script o realiza otras acciones post-explosión
    }
}