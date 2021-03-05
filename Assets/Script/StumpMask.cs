using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpMask : MonoBehaviour
{
    void Start()
    {
        // Used to correcting the position
        var bounds = GetComponent<SpriteMask>().bounds;
        var halfHeight = (bounds.max.y - bounds.min.y) / 2f;
        transform.position += new Vector3(0f, halfHeight, 0f);
    }
}
