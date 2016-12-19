using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField]
    int health = 3;

    void CheckDead()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().Sleep();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword")
        {
            health--;
            CheckDead();
        }
    }
}
