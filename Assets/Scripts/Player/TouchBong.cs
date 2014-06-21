using UnityEngine;
using System.Collections;

public class TouchBong : MonoBehaviour {
	public DogControler dc;
	public CatController cc;
	public BossController bc;
	private bool clicked;
	public int BongHP;
	public bool isCat;
	public bool isBoss;

	public void OnMouseEnter () {
		BongHP--;
		if (!isCat)
		dc.TouchBalloon ();
		else 
		cc.TouchBalloonCat();
//		if (!isBoss)
//		dc.TouchBalloon ();
//		else
//		bc.TouchBalloonBoss ();
		if(BongHP==0)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if(!isCat)
		{
		if (coll.gameObject.name == "wall 1") {
			dc.direction = new Vector2 (Random.Range (0.2f, 1f), Random.Range (0.2f, 1f));
			dc.direction.Normalize ();
			transform.parent.rigidbody2D.velocity = dc.direction * dc.baseSpeed;
		} 
		else if (coll.gameObject.name == "wall 2") 
			{
			dc.direction = new Vector2 (Random.Range (-1f, -0.2f), Random.Range (0.2f, 1f));
			dc.direction.Normalize ();
			transform.parent.rigidbody2D.velocity = dc.direction * dc.baseSpeed;
			}
		}

	else
	{
		if (coll.gameObject.name == "wall 1") {
			cc.direction = new Vector2 (Random.Range (0.2f, 1f), Random.Range (0.2f, 1f));
			cc.direction.Normalize ();
			transform.parent.rigidbody2D.velocity = cc.direction * cc.baseSpeed;
		} else if (coll.gameObject.name == "wall 2") {
			cc.direction = new Vector2 (Random.Range (-1f, -0.2f), Random.Range (0.2f, 1f));
			cc.direction.Normalize ();
			transform.parent.rigidbody2D.velocity = cc.direction * cc.baseSpeed;
		}
	}
//	 	if(!isBoss)
//		{
//			if (coll.gameObject.name == "wall 1") {
//				dc.direction = new Vector2 (Random.Range (0.2f, 1f), Random.Range (0.2f, 1f));
//				dc.direction.Normalize ();
//				transform.parent.rigidbody2D.velocity = dc.direction * dc.baseSpeed;
//			} else if (coll.gameObject.name == "wall 2") {
//				dc.direction = new Vector2 (Random.Range (-1f, -0.2f), Random.Range (0.2f, 1f));
//				dc.direction.Normalize ();
//				transform.parent.rigidbody2D.velocity = dc.direction * dc.baseSpeed;
//			}
//		}
//		else
//		{
//			if (coll.gameObject.name == "wall 1") {
//				bc.direction = new Vector2 (Random.Range (0.2f, 1f), Random.Range (0.2f, 1f));
//				bc.direction.Normalize ();
//				transform.parent.rigidbody2D.velocity = bc.direction * bc.baseSpeed;
//			} else if (coll.gameObject.name == "wall 2") {
//				bc.direction = new Vector2 (Random.Range (-1f, -0.2f), Random.Range (0.2f, 1f));
//				bc.direction.Normalize ();
//				transform.parent.rigidbody2D.velocity = bc.direction * bc.baseSpeed;
//			}
//		}

}
}
