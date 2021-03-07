using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBook : MonoBehaviour, IBook
{
    bool takeable = true;

    public void Collision(Collider2D col)
    {
        var player = col.gameObject.GetComponent<PlayerController>();
        if (player != null && player.currentAbility == null && takeable)
        {
            Debug.Log("Add fire ability");
            player.animator.SetBool("isHoldingFireBook", true);
            var ability = col.gameObject.AddComponent<FireAbility>();
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
