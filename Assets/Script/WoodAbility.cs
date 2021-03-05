using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodAbility : MonoBehaviour, IAbility
{
    public GameObject prefab;

    public void Start()
    {
        prefab = (GameObject)Resources.Load("Prefab/Stump");
    }

    public void Cast(PlayerController player)
    {
        var hit = Physics2D.Raycast(player.transform.position, Vector2.down);
        if (hit.collider != null)
        {
            Instantiate(prefab, hit.point, Quaternion.identity);
            Destroy(this);
        }
    }
}
