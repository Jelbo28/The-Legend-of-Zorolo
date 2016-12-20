using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField]
    int health = 3;
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    float flashTime = 0.2f;

    private bool gettum = false;
    private Transform target;

    void Update()
    {
        Debug.Log(gettum);
        if (gettum == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

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
            StartCoroutine(ColorFlash());
            health--;
            CheckDead();
        }
        if (other.tag == "Player")
        {
            target = other.GetComponent<Transform>();
            Debug.Log("Whyyyyyy");
            gettum = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CancelInvoke();
        }
    }

    IEnumerator ColorFlash()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(flashTime);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
