using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFX : MonoBehaviour
{
    [SerializeField] GameObject hitEffectPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Instantiate(hitEffectPrefab, collision.GetContact(0).point, Quaternion.identity);
        }
    }
}
