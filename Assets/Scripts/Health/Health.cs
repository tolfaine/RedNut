using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth;

	public bool isAlly;
	protected int health;

	protected virtual void Awake () {
		health = maxHealth;
	}

	protected virtual void Start () {
	}

	protected virtual void Update () {
	
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
				TakeDamage(projectile.getDamage());
				Destroy(projectile.gameObject);
			}
		}
	}

	public virtual void TakeDamage(int damageCount)
	{
		health -= damageCount;

		if (health <= 0) {
			Die ();
			Destroy (this.gameObject);
		}

	}

	protected virtual void OnDestroy ()
	{

	}
	protected virtual void Die(){
		
		
	}

	


}
