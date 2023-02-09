using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Collectible : MonoBehaviour
{
    [SerializeField]
    protected float intensity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() == null) return;
        Collect(other.gameObject);
    }

    protected virtual void Collect(GameObject playerRef)
    {
        Destroy(this.gameObject);
    }
}
