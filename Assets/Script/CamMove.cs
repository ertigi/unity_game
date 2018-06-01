using UnityEngine;

public class CamMove : MonoBehaviour {

	public GameObject player;

	void Update () {
		transform.position = new Vector3 (player.transform.position.x, 3f, -8f);
	}
}
