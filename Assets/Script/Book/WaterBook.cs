using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBook : MonoBehaviour, IBook
{
    bool takeable = true;

    public void Collision(Collider2D col)
    {
        var player = col.gameObject.GetComponent<PlayerController>();
        if (player != null && player.currentAbility == null && takeable)
        {
            Debug.Log("Add water ability");
            player.animator.SetBool("isHoldingWaterBook", true);
            var ability = col.gameObject.AddComponent<WaterAbility>();
            player.currentAbility = ability;
            Destroy(gameObject);
        }
    }

    public void UntakeableFor(float time=3f)
    {
        StartCoroutine(UntakeableForCoroutine(time));
    }

    IEnumerator UntakeableForCoroutine(float time)
    {
        takeable = false;
        yield return new WaitForSeconds(time);
        takeable = true;
    }
}
