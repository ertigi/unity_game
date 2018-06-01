using UnityEngine;

public class playerCtrl : MonoBehaviour {

	public float speed = 20f;
	private Rigidbody2D q;

	void Start () {
		q = GetComponent <Rigidbody2D> ();
	}

	void Update () {
		float moveX = Input.GetAxis ("Horizontal");
		q.MovePosition (q.position + Vector2.right * moveX * speed * Time.deltaTime);
	
		if (Input.GetKeyDown (KeyCode.Space))
			q.AddForce (Vector2.up * 10000);
	}

}
