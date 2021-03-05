using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBook : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        var player = col.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.isAbleToUseFireball = true;
            Destroy(gameObject);
        }
    }
}
