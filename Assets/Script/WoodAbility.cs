using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodAbility : MonoBehaviour, IAbility
{
    public GameObject prefabStump;
    public WoodBook prefabWoodBook;

    public void Start()
    {
        prefabStump = (GameObject)Resources.Load("Prefab/Stump");
        prefabWoodBook = Resources.Load<WoodBook>("Prefab/WoodBook");
    }

    public void Cast(PlayerController player)
    {
        var hit = Physics2D.Raycast(player.transform.position, Vector2.down);
        if (hit.collider != null)
        {
            Instantiate(prefabStump, hit.point, Quaternion.identity);
            Destroy(this);
        }
    }

    public void Drop(PlayerController player)
    {
        var woodBook = Instantiate(prefabWoodBook, player.transform.position, player.transform.rotation);
        woodBook.DisableCollision();
        Destroy(this);
    }
}
