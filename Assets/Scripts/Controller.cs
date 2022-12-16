using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

	void Awake () {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
  
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        DogeMovement();
	}

    void DogeMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
            audioSource.PlayOneShot(flyClip);
        }

        if (myBody.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }else if (myBody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -45, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    //public void flapbutton()
    //{
    //    didflap = true;
    //}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder")
        {
            audioSource.PlayOneShot(pingClip);
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            audioSource.PlayOneShot(diedClip);
            anim.SetTrigger("Died");
        }
    }

}
