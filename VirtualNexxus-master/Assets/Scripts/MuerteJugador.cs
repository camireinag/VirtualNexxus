using UnityEngine;
using System.Collections;

public class MuerteJugador : MonoBehaviour
{
	public int CurrentHealth = 20; //Se le dice la vida
	public int damage = 1; //Daño aplicado

	//Que el trigger del enemigo dañe al jugador
	private void OnTriggerEnter(Collider other)
	{
		if (GameObject.FindWithTag("Enemy"))
		{
			DamagePlayer(damage);
		}
	}
	//Cantidad de daño aplicado a la vida, si llega a 0 se destruye el objeto
	public void DamagePlayer(int damageAmount)
	{
		CurrentHealth -= damageAmount;
		if (CurrentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}
}