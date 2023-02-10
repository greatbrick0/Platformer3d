using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : Collectible
{
    protected override void Collect(GameObject playerRef)
    {
        playerRef.GetComponent<PlayerMovement>().IncreaseSpeed(intensity);
        base.Collect(playerRef);
    }
}
