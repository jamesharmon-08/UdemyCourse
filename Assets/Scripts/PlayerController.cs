using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;

    public Rigidbody2D theRB;

    private Animator anim;

    public SpriteRenderer theSR;

    public Sprite[] playerDirectionSprites;

    public Animator weaponAnim;

    private bool isKnockingBack;

    public float knockbackTime, knockbackForce;
    private float knockbackCounter;
    private Vector2 knockbackDir;

    public GameObject HitEffect;

    public float dashSpeed, dashLength;
    private float dashCounter, activeMoveSpeed;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theRB = GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isKnockingBack)
        {
            //transform.position = new Vector3(transform.position.x + (Input.GetAxisRaw("Horizontal")) * moveSpeed*Time.deltaTime, transform.position.y+(Input.GetAxisRaw("Vertical")) * moveSpeed*Time.deltaTime,transform.position.z);

            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * activeMoveSpeed;

            anim.SetFloat("Speed",theRB.velocity.magnitude);

            if(theRB.velocity != Vector2.zero)  // Movement direction
            {
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    theSR.sprite= playerDirectionSprites[1];
                    if (Input.GetAxisRaw("Horizontal")<0 )
                    {
                        theSR.flipX = true;

                        weaponAnim.SetFloat("dirX",-1f);
                        weaponAnim.SetFloat("dirY",0f);
                    } else
                    {
                        theSR.flipX = false;
                        weaponAnim.SetFloat("dirX",1f);
                        weaponAnim.SetFloat("dirY",0f);
                    }
                } else
                {
                    if(Input.GetAxisRaw("Vertical") < 0)
                    {
                        theSR.sprite = playerDirectionSprites[0];
                        weaponAnim.SetFloat("dirX",0f);
                        weaponAnim.SetFloat("dirY",-1f);
                    } else
                    {
                        theSR.sprite = playerDirectionSprites[2];
                        weaponAnim.SetFloat("dirX",0f);
                        weaponAnim.SetFloat("dirY",1f);
                    }
                }
                
            }

            if(Input.GetMouseButtonDown(0))
            {
                weaponAnim.SetTrigger("Attack");
            }
            if(dashCounter <= 0)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter=dashLength;
                }
            } else
            {
                dashCounter -= Time.deltaTime;
                if(dashCounter <= 0)
                {
                    activeMoveSpeed = moveSpeed;
                }
            }

        } else 
        {
            knockbackCounter -= Time.deltaTime;
            theRB.velocity = knockbackDir * knockbackForce;
            if(knockbackCounter <= 0)
            {
                isKnockingBack = false;
            }
        }
    }

    public void KnockBack(Vector3 knockerPosition)
    {
        knockbackCounter = knockbackTime;
        isKnockingBack = true;

        knockbackDir = transform.position - knockerPosition;
        knockbackDir.Normalize();
        Instantiate(HitEffect, transform.position, transform.rotation);
    }
}
