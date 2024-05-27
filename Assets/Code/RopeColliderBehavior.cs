using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeColliderBehavior : MonoBehaviour
{
    [SerializeField] private float colliderLifetime;
    [SerializeField] private float timeBetweenColliders;
    [SerializeField] private Collider2D _collider;

    private void OnEnable()
    {
        StartCoroutine(ColliderStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ColliderStart()
    {
        yield return new WaitForSeconds(1f);
        // Insantiate colliderPrefab
        // Wait colliderLifetime
        // Delete colliderPrefab
        // Wait timeBetweenColliders
        while (true) {
            _collider.enabled = true;
            yield return new WaitForSeconds(colliderLifetime);
            _collider.enabled = false;
            yield return new WaitForSeconds(timeBetweenColliders);
            if(colliderLifetime > 0.5f && timeBetweenColliders > 0.5f) { 
                colliderLifetime -= 0.05f;
                timeBetweenColliders -= 0.05f;
            }
        }
    }
}
