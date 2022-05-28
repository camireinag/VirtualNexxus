using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuerteJugador : MonoBehaviour
{
	public int damage = 1; //Daño aplicado
	public int heal= 1;
	[SerializeField] int CurrentHealth = 20;//Se le dice la vida
	[SerializeField] Text vida; //Texto de vida
	//Que el trigger del enemigo dañe al jugador
	private void OnTriggerEnter(Collider other)
	{
		if (GameObject.FindWithTag("Enemy"))
		{
			DamagePlayer(damage);
		}
       /* if (GameObject.FindWithTag("Heal")) 
		{
			HealPlayer(heal);
		}*/
	}
	//Cantidad de daño aplicado a la vida, si llega a 0 se destruye el objeto
	public void DamagePlayer(int damageAmount)
	{
		CurrentHealth -= damageAmount;
		vida.text = string.Format("{00}", CurrentHealth);
		if (CurrentHealth <= 0)
		{
			Destroy(gameObject);
			ControlEscenas.CambiarEscenaStatic(ControlEscenas.Levels.GameOver);
		}
	}
	/*public void HealPlayer(int healAmount) 
	{
		CurrentHealth += healAmount;
		vida.text = string.Format("{00}", CurrentHealth);

	}*/
}