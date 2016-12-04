using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth;

	public bool isAlly;
	public int health;
	protected bool isDying = false;
	protected bool readyToSelfDestroy = false;
	protected bool destroyActivated = false;
	public Animator animator;

	public bool invulnerable = true;
	public bool fell = false;

	public GameObject fxBlood;
	GameObject blood = null;
	protected virtual void Awake () {
		health = maxHealth;
	}

	protected virtual void Start () {
		//SetInvulnerability (false);
		animator = GetComponent<Animator>();
	}

	protected virtual void Update () {

		if (isDying == true) {
			animator.SetBool ("dead", true);

			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("mort") || animator.GetCurrentAnimatorStateInfo (0).IsName ("dead")  &&
				animator.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1.0f) {

				if (blood == null) {
					blood = Instantiate (fxBlood, transform.position, transform.rotation) as GameObject;
					blood.transform.parent = this.transform;
					Transform groun = transform.FindChild ("GroundPoint");
					blood.transform.localPosition = new Vector3 (0f, -8f, 0f);
					blood.transform.FindChild ("GroundPoint").transform.position = new Vector3 (groun.position.x, groun.position.y-0.5f -blood.transform.localPosition.y , groun.position.z);
					blood.GetComponent<Animator> ().SetBool ("active", true);
					fell = true;
				}

				if (blood.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("sang") &&
					blood.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime >= 1.0f) {
						readyToSelfDestroy = true;
				}
					
			}

		}


	}
	public virtual void Resurect(){
		health = maxHealth / 2;
		isDying = false;
		readyToSelfDestroy = false;
		destroyActivated = false;
		fell = false;


		GetComponent<AttackLogic> ().Resurect ();
	}

	public void SetInvulnerability(bool newVulnerability){
		invulnerable = newVulnerability;
	}

	protected virtual void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		if (!invulnerable) {
			Projectile projectile = otherCollider.gameObject.GetComponent<Projectile> ();
			if (projectile != null) {

				// Avoid friendly fire
				if (projectile.getIsAlly () != isAlly) {
					ModifHealth (projectile.getDamage ());
					Destroy (projectile.gameObject);
				}
			}
		}
	}

	public virtual void ModifHealth(int damageCount)
	{
		if (invulnerable) {
			
		} else {
			health -= damageCount;
		}

		if (health > maxHealth) {
			health = maxHealth;
		}

		if (health <= 0) {
			health = 0;
			Die ();
			//Destroy (this.gameObject);
		}


	}

	protected virtual void OnDestroy ()
	{

	}
	protected virtual void Die(){
		isDying = true;
		foreach (Collider2D c in GetComponents<Collider2D>()) {
			c.enabled = false;
		}
		GetComponent<AttackLogic> ().IsDyingFunc ();
	}


	public bool isItDying(){
		return isDying;
	}
	

	public bool getIsAlly(){
		return isAlly;
	}
}
