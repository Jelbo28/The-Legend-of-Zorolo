using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    KeyCode attack;

    private Animator anim;
    private float moveHorizontal;
    private float moveVertical;


    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(moveHorizontal, moveVertical, 0f);
        Animate();
    }

    void Animate()
    {
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_x", moveHorizontal);
            anim.SetFloat("input_y", moveVertical);
        }
        else
        {
            anim.SetBool("isWalking", false);
            //anim.SetFloat("input_x", 0f);
            //anim.SetFloat("input_y", 0f);
        }
        if (Input.GetKeyDown(attack))
        {
            anim.SetTrigger("Attack");
        }
    }
}
