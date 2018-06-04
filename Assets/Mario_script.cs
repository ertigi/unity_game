using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_script : MonoBehaviour {

    public float speed = 1.0f;
    public float jumpSpeed = 0.5f;
    public LayerMask groundLayer;

    private Animator marioAnimator;
    private Transform gCheck;
    private float scaleX = 1.0f;
    private float scaleY = 1.0f;

    // Use this for initialization
    void Start () {
        marioAnimator = GetComponent<Animator>();
        gCheck = transform.Find("GCheck");

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float mSpeed = Input.GetAxis("Horizontal");
        marioAnimator.SetFloat("Speed", Mathf.Abs(mSpeed));
        bool isTouched = Physics2D.OverlapPoint(gCheck.position, groundLayer);

        if (Input.GetKey(KeyCode.Space))
        {
            if (isTouched)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
                isTouched = false;
            }
        }
        marioAnimator.SetBool("isTouched", isTouched);

        if (mSpeed > 0)
        {
            transform.localScale = new Vector2(scaleX, scaleY);
        }
		else if (mSpeed < 0){
            transform.localScale = new Vector2(-scaleX, scaleY);
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(mSpeed * speed, GetComponent<Rigidbody2D>().velocity.y);
        
    }
}
