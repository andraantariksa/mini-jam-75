using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAbility : MonoBehaviour, IAbility
{
    public GameObject prefabWaterSpawner;
    public WaterBook prefabWaterBook;
    public float FireDelay  = 3f;
    float currentFireDelay = 0f;
    GameObject currentWaterSpawner = null;

    public void Start()
    {
        prefabWaterSpawner = (GameObject)Resources.Load("Prefab/Water2D Spawner");
        prefabWaterBook = Resources.Load<WaterBook>("Prefab/WaterBook");
    }

    public void Cast(PlayerController player)
    {
        if (currentFireDelay <= 0f)
        {
            var hit = Physics2D.Raycast(player.transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));
            if (hit.collider != null)
            {
                player.animator.SetTrigger("useWaterAbility");
                DestroyWaterSpawner();
                if (hit.collider.gameObject.tag == "Pedestal")
                {
                    hit.collider.GetComponent<Pedestal>().Spell(SpellType.Water);
                }
                else
                {
                    currentWaterSpawner = Instantiate(prefabWaterSpawner, hit.point, Quaternion.identity);
                }
            }
            currentFireDelay = FireDelay;
        }
    }

    public void Drop(PlayerController player)
    {
        player.animator.SetBool("isHoldingWaterBook", false);
        var waterBook = Instantiate(prefabWaterBook, player.firePoint.transform.position, player.transform.rotation);
        waterBook.UntakeableFor();
        player.currentAbility = null;
        DestroyWaterSpawner();
        Destroy(this);
    }

    void Update()
    {
        if (currentFireDelay > 0f)
        {
            currentFireDelay -= Time.deltaTime;
        }
    }

    void DestroyWaterSpawner()
    {
        if (currentWaterSpawner != null)
        {
            var waterSpawner = currentWaterSpawner.GetComponent<Water2DSpawner>();
            waterSpawner.DestroyAll();
            Destroy(currentWaterSpawner);
        }
    }
}
