using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : Collectible
{
    private float rotationAmount = 0.0f;
    [SerializeField]
    private float rotationSpeed = 180.0f;

    void Update()
    {
        rotationAmount = Mathf.Repeat(rotationAmount, 360);
        transform.eulerAngles = new Vector3(0, rotationAmount * rotationSpeed, 0);
    }

    protected override void Collect(GameObject playerRef)
    {
        playerRef.GetComponent<CoinTracker>().AddCoins(Mathf.RoundToInt(intensity));
        base.Collect(playerRef);
    }
}
