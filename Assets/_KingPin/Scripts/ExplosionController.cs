using System;
using System.Collections;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private string lootTagName = "Money";
    private string blockingTag = "Pin";

    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the specified tag for deactivation
        if (other.CompareTag(lootTagName))
        {
            // Check for an object with a blocking tag between the collider center and the object
            Vector3 direction = other.transform.position - transform.position;
            if (!Physics.Raycast(transform.position, direction, out RaycastHit hit, direction.magnitude) || 
                hit.collider.CompareTag(blockingTag) == false)
            {
                // Deactivate the object
                other.gameObject.SetActive(false);
            }
        }
    }
}
