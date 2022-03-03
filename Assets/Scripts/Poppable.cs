using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poppable : MonoBehaviour
{
    public GameObject popEffectPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.parent == null && collision.gameObject.GetComponent<Poppable>() == null && !collision.gameObject.tag.Equals("Gun"))
        {
            PopBalloon();
        }
    }

    private void PopBalloon()
    {
        if (popEffectPrefab != null)
        {
            GameObject effect = Instantiate(popEffectPrefab, transform.position, transform.rotation);
            Destroy(effect, 1f);
        }
        Destroy(gameObject);
    }
}
