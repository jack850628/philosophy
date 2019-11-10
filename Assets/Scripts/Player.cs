using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyLeft, keyRight, keyJump;
    private float speed = 12f;
    private Rigidbody rigidbody;
    private Animator animator;
    private float deadRad;
    private int _score;
    private AudioSource audioSource;


    public int score
    {
        get => _score;
        set
        {
            _score = value;
            scoreText.text = _score.ToString();
            if (_score < 0)
                goTobDead();
        }
    }
    public bool canJump;
    public Text scoreText;
    public GameObject deathExplosion;
    public AudioClip explosionAudio, jump;

    public enum PlayerStatus
    {
        LIFE,
        DEADING,
        DEADED
    }
    public PlayerStatus playerStatus;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = transform.GetComponent<Animator>();
        playerStatus = PlayerStatus.LIFE;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameStatus.gameStatus != GameStatus.Status.RUNNING) return;
        if (playerStatus == PlayerStatus.LIFE)
        {
            if (Input.GetKey(keyLeft))
            {
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                transform.Translate(new Vector2(-speed, 0f) * Time.deltaTime);
                if (canJump)
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
                audioSource.PlayOneShot(jump);
                animator.Play("none");
            }
            if(transform.position.y < -5)
            {
                if (explosionAudio != null)
                {
                    audioSource.clip = explosionAudio;
                    audioSource.Play();
                }
                playerStatus = PlayerStatus.DEADED;
                Invoke("resurrection", 3f);
            }
        }
        else if(playerStatus == PlayerStatus.DEADING)
        {
            transform.Find("Cube").Find("image").Rotate(Vector3.forward * 2000 * Time.deltaTime);
            if (transform.position.y < -5)//防止死亡時沒有撞到牆壁就往下掉時
            {
                playerStatus = PlayerStatus.DEADED;
                Invoke("resurrection", 3f);
            }
        }
    }
    public void goTobDead()
    {
        deadRad = Random.Range(-45f, 45f) * Mathf.Deg2Rad;
        rigidbody.AddForce(new Vector2(Mathf.Sin(deadRad) * 30, Mathf.Cos(deadRad) * 30), ForceMode.Impulse);
        GetComponent<Collider>().isTrigger = true;
        playerStatus = PlayerStatus.DEADING;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerStatus == PlayerStatus.DEADING && other.gameObject.CompareTag("Wall"))
        {
            if(explosionAudio != null)
            {
                audioSource.clip = explosionAudio;
                audioSource.Play();
            }
            playerStatus = PlayerStatus.DEADED;
            var de = Instantiate(deathExplosion);
            de.transform.position = transform.position;
            Destroy(de, 0.5f);
            Invoke("resurrection", 3f);
        }
    }
    private void resurrection()
    {
        var newPlayer = Instantiate(gameObject);
        newPlayer.transform.position = new Vector3(0f, 0f, -0.09603548f);
        newPlayer.GetComponent<Collider>().isTrigger = false;
        var player = newPlayer.GetComponent<Player>();
        player.playerStatus = PlayerStatus.LIFE;
        player.GetComponent<Rigidbody>().velocity = new Vector3();
        player.score = 0;
        newPlayer.transform.Find("Cube").Find("image").transform.rotation = Quaternion.identity;
        Destroy(gameObject);
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
