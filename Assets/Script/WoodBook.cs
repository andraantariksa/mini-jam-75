using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBook : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        var player = col.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            col.gameObject.AddComponent<WoodAbility>();
            Destroy(gameObject);
        }
    }
}
