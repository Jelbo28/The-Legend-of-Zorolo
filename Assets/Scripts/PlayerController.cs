using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Text score;
    [SerializeField]
    float speed;
    [SerializeField]
    KeyCode[] attack;
    [SerializeField]
    Transform[] spawn;
    [SerializeField]
    int facingDirection = 0;
    [SerializeField]
    GameObject projectilePrefab;

    private Animator anim;
    private float moveHorizontal;
    private float moveVertical;
    private string bob;
    private Transform projectile;
    private GameObject ProjectileGO;
    private int points;

    //public int damageInflcited = 0;


    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(moveHorizontal, moveVertical, 0f);
        FacingDirection();
        Animate();
    }

    public void Projectile()
    {
        if (GetComponent<Damager>().health >= GetComponent<Damager>().initialHealth && anim.GetBool("isWalking") == false)
        {
            //int spawnNum = 0;
            //if (Input.GetKey("up"))
            //{
            //    spawnNum = 3;
            //}
            //else if (Input.GetKey("down"))
            //{
            //    spawnNum = 2;
            //}
            //else if (Input.GetKey("left"))
            //{
            //    spawnNum = 1;
            //}
            //else if (Input.GetKey("right"))
            //{
            //    spawnNum = 0;
            //}
            projectile = spawn[facingDirection];

            ProjectileGO = Instantiate(projectilePrefab, projectile.position, projectile.rotation) as GameObject;
        }
    }

    public void ProjectileEnd()
    {
        anim.SetBool("Projectile", false);
    }

    public void Score(int value)
    {
        points += value;
        score.text = "Score: " + points;
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
        if (Input.GetKeyDown(attack[0]))
        {
            anim.SetTrigger("Attack");
           
  
                Debug.Log("GO");
                //anim.SetBool("Projectile", true);
                //anim.
                Projectile();
        }
    }

    void FacingDirection()
    {
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            facingDirection = 0;
            //Debug.Log("up");
        }
        else if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            facingDirection = 1;
            //Debug.Log("down");
        }
        else if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            facingDirection = 2;
            //Debug.Log("left");
        }
        else if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            facingDirection = 3;
            //Debug.Log("right");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

    }
}
