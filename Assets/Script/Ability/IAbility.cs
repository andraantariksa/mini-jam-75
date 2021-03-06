using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void Cast(PlayerController player);
    void Drop(PlayerController player);
}
