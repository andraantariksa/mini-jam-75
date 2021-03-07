using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility : MonoBehaviour, IAbility
{
    public GameObject prefabFireball;
    public FireBook prefabFireBook;
    public float FireDelay  = 3f;
    float currentFireDelay = 0f;

    public void Start()
    {
        prefabFireball = (GameObject)Resources.Load("Prefab/Fireball");
        prefabFireBook = Resources.Load<FireBook>("Prefab/FireBook");
    }

    public void Cast(PlayerController player)
    {
        if (currentFireDelay <= 0f)
        {
            player.animator.SetTrigger("useFireAbility");
            var hit = Physics2D.Raycast(player.transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));
            if (hit.collider != null && hit.collider.gameObject.tag == "Pedestal")
            {
                hit.collider.GetComponent<Pedestal>().Spell(SpellType.Fire);
            }
            else
            {
                Instantiate(prefabFireball, player.firePoint.transform.position, player.firePoint.transform.rotation);
            }
            currentFireDelay = FireDelay;
        }
    }

    public void Drop(PlayerController player)
    {
        player.animator.SetBool("isHoldingFireBook", false);
        var fireBook = Instantiate(prefabFireBook, player.transform.position, player.transform.rotation);
        fireBook.UntakeableFor();
        player.currentAbility = null;
        Destroy(this);
    }

    void Update()
    {
        if (currentFireDelay > 0f)
        {
            currentFireDelay -= Time.deltaTime;
        }
    }
}
