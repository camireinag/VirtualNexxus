using UnityEngine;
using System.Collections;

public class MuerteEnemigo : MonoBehaviour 
{
	public int CurrentHealth = 20; //Se le dice la vida
	public int damage = 1; //Daño aplicado

	//Pegar al enemigo con la bala, que cuando entre al trigger le haga daño
	private void OnTriggerEnter(Collider other) 
	{
		if (GameObject.FindWithTag("Bullet")) 
		{
			DamageEnemy(damage);
		}
	}
	//Cantidad de daño aplicado a la vida, si llega a 0 se destruye el objeto
	public void DamageEnemy(int damageAmount) 
	{
		CurrentHealth -= damageAmount;
		if (CurrentHealth <= 0) 
		{
			Destroy(gameObject);
		}
	}
}

