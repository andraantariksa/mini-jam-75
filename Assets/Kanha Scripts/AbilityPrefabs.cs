using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPrefabs : MonoBehaviour
{
    public float prefabDeletingTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(prefabDeletingTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            prefabDeletingTime -= Time.deltaTime;
        }
    }
}
