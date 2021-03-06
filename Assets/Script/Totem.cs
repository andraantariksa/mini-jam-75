using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TotemState
{
    Stone,
    Wood,
    OnFire,
    Burnt
};

public class Totem : MonoBehaviour
{
    public TotemState state = TotemState.Stone;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool Spell(SpellType spellType)
    {
        var works = false;
        switch (spellType)
        {
            case SpellType.Wood:
                if (state == TotemState.Stone)
                {
                    // Change the sprite to wood sprite
                    state = TotemState.Wood;
                    works = true;
                }
                break;
            case SpellType.Fire:
                if (state == TotemState.Wood)
                {
                    // Change the sprite to on fire sprite with the animation?
                    state = TotemState.OnFire;
                    works = true;
                }
                break;
            case SpellType.Water:
                if (state == TotemState.OnFire)
                {
                    // Change the sprite to burnt
                    state = TotemState.Burnt;
                    works = true;
                }
                break;
        };
        return works;
    }
}
