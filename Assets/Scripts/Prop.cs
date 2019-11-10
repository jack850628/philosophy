using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

//道具
public class Prop : MonoBehaviour
{
	public int score;
    public GameObject deathExplosion;
    public int mass, drag;
    public bool isPositive;
    public AudioClip audioClip;

    protected void Start()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.mass = mass;
        rigidbody.drag = drag;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(audioClip != null)
            {
                var audioSource = collision.gameObject.GetComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.Play();
            }
            Debug.Log("吃");
            if(!isPositive)
                collision.gameObject.transform.DOShakePosition(0.5f, new Vector2(0.3f, 0.3f));
            collision.gameObject.GetComponent<Player>().score += score;
            var de = Instantiate(deathExplosion);
            de.transform.position = collision.contacts[0].point;
            Destroy(de, 0.5f);
            Destroy(gameObject);
		}
        else if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
