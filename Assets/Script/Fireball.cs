using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 3f;
    // public GameObject impactEffect;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage();
		}

        // Fireball effect
		// Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
    }
}
