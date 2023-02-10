using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingScript : MonoBehaviour
{
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private Vector3 camOffset;

    private void Update()
    {
        cam.position = transform.position + camOffset;
    }
}
