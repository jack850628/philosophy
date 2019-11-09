using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyLeft, keyRight, keyJump;
    private float speed = 12f;
    private Rigidbody rigidbody;
    private Animator animator;


    public bool canJump;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = transform.GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameStatus.gameStatus != GameStatus.Status.RUNNING) return;
        if (Input.GetKey(keyLeft))
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            transform.Translate(new Vector2(-speed, 0f) * Time.deltaTime);
            if(canJump)
                animator.Play("Move");
        }
        if (Input.GetKey(keyRight))
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            transform.Translate(new Vector2(speed, 0f) * Time.deltaTime);
            if (canJump)
                animator.Play("Move");
        }
        if (Input.GetKey(keyJump) && canJump)
        {
            canJump = false;
            rigidbody.velocity = new Vector2(rigidbody.velocity.y, 0);
            rigidbody.AddForce(new Vector2(0, 12), ForceMode.Impulse);
            animator.Play("none");
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prop"))
        {
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = false;
        }
    }*/
}
