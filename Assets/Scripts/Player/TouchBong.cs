using UnityEngine;
using System.Collections;

public class TouchBong : MonoBehaviour {
	private DogControler dc;
	private bool clicked;
	public int BongHP;
	void Start () {
		dc = transform.parent.gameObject.GetComponent<DogControler> ();
	}

	public void OnMouseEnter () {
		BongHP--;
		dc.TouchBalloon ();
		if(BongHP==0)
		Destroy (gameObject);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.name == "wall 1" || coll.gameObject.name == "wall 2") {
			DogControler tmp = transform.parent.GetComponent<DogControler> ();
		if (coll.gameObject.name == "wall 1") {
				tmp.direction = new Vector2 (Random.Range (0.2f, 1f), Random.Range (0.2f, 1f));
			tmp.direction.Normalize ();
			transform.parent.rigidbody2D.velocity = tmp.direction * tmp.baseSpeed;
		} else if (coll.gameObject.name == "wall 2") {
				tmp.direction = new Vector2 (Random.Range (-1f, -0.2f), Random.Range (0.2f, 1f));
				tmp.direction.Normalize ();
				transform.parent.rigidbody2D.velocity = tmp.direction * tmp.baseSpeed;
		}
		}
	}

}
