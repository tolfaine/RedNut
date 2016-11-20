using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth;

	public bool isAlly;
	protected int health;
	protected bool isDying = false;
	protected bool readyToSelfDestroy = false;

	protected virtual void Awake () {
		health = maxHealth;
	}

	protected virtual void Start () {
	}

	protected virtual void Update () {

		if (isDying == true) {
			readyToSelfDestroy = true;
		}
		if (readyToSelfDestroy) {
			Destroy (this.gameObject);
		}
	}

	protected virtual void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		Projectile projectile = otherCollider.gameObject.GetComponent<Projectile>();
		if (projectile != null)
		{

			// Avoid friendly fire
			if (projectile.getIsAlly() != isAlly)
			{
				ModifHealth(projectile.getDamage());
				Destroy(projectile.gameObject);
			}
		}
	}

	public virtual void ModifHealth(int damageCount)
	{
		health -= damageCount;

		if (health <= 0) {
			Die ();
			//Destroy (this.gameObject);
		}

	}

	protected virtual void OnDestroy ()
	{

	}
	protected virtual void Die(){
		isDying = true;
		
	}


	public bool isItDying(){
		return isDying;
	}
	

	public bool getIsAlly(){
		return isAlly;
	}
}
