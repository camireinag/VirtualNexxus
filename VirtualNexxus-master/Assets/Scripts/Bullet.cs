using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float speed = 8f;
	public float lifeDuration = 2f;
	float lifeTimer;
	public int attack = 1;

	public bool shootByPlayer;

	private void OnEnable()
	{
		lifeTimer = lifeDuration;
	}

	private void Update()
	{
		lifeTimer -= Time.deltaTime;
		if(lifeTimer<=0)
		{
			gameObject.SetActive(false);
		}
	}

	private void FixedUpdate()
	{
		transform.position += transform.forward * speed * Time.fixedDeltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Bullet choca = " + other.name);
		bool remove = true;

		IDamage damage = other.GetComponent<IDamage>();
		if(damage != null)
		{
			remove= damage.DoDamage(attack, shootByPlayer);
		}
		if(remove ==true) gameObject.SetActive(false);
	}
}