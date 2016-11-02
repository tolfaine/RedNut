using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public bool isAlly;
	public int health;
	public int maxHealth;

	void Start () {
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
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

	public void TakeDamage(int damageCount)
	{
		health -= damageCount;
		if (health <= 0) {
			Destroy (this.gameObject);
		}

	}

	void OnDestroy ()
	{

	}


	


}
