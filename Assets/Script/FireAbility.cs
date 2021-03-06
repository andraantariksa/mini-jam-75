using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility : MonoBehaviour, IAbility
{
    public GameObject prefabFireball;
    public FireBook prefabFireBook;

    public void Start()
    {
        prefabFireball = (GameObject)Resources.Load("Prefab/Fireball");
        prefabFireBook = Resources.Load<FireBook>("Prefab/FireBook");
    }

    public void Cast(PlayerController player)
    {
        Instantiate(prefabFireball, player.firePoint.position, player.transform.rotation);
    }

    public void Drop(PlayerController player)
    {
        var fireBook = Instantiate(prefabFireBook, player.transform.position, player.transform.rotation);
        fireBook.DisableCollision();
        Destroy(this);
    }
}
