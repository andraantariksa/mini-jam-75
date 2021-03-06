using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAbility : MonoBehaviour, IAbility
{
    public GameObject prefabWaterSpawner;
    public WaterBook prefabWaterBook;

    public void Start()
    {
        prefabWaterSpawner = (GameObject)Resources.Load("Prefab/Water2D Spawner");
        prefabWaterBook = Resources.Load<WaterBook>("Prefab/WaterBook");
    }

    public void Cast(PlayerController player)
    {
        var hit = Physics2D.Raycast(player.transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            Instantiate(prefabWaterSpawner, hit.point, Quaternion.identity);
            Destroy(this);
        }
    }

    public void Drop(PlayerController player)
    {
        var waterBook = Instantiate(prefabWaterBook, player.transform.position, player.transform.rotation);
        waterBook.DisableCollision();
        Destroy(this);
    }
}
