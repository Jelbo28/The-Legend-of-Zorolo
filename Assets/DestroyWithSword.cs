using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithSword : MonoBehaviour
{
    [SerializeField]
    Sprite[] state;
    private SpriteRenderer playerRender;
	// Use this for initialization
	void Start ()
    {
        playerRender = GetComponent<SpriteRenderer>();
        playerRender.sprite = state[0];
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword" || other.tag == "Projectile")
        {
            playerRender.sprite = state[1];
            other.gameObject.GetComponent<Damager>().Attacked(-1f);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
