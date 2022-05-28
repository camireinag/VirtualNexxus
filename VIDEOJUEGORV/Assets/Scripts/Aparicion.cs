using UnityEngine;
using System.Collections;

public class Aparicion : MonoBehaviour
{
	public Transform Enemy;
	private float Timer;
	// Use this for initialization
	void Start()
	{
		Timer = Time.time + 2;// THIS (15) IS THE SECONDS (TIME) IN WHICH THE ENEMY IS GOING TO SPAWN FOR THE FIRST TIME 
	}
	// Update is called once per frame
	void Update()
	{
		if (Timer < Time.time)
		{ //This checks wether real time has caught up to the timer
			Instantiate(Enemy, transform.position, transform.rotation); //This spawns the emeny
			Timer = Time.time + 8; // THIS (15) IS THE SECONDS (TIME) IN WHICH THE ENEMY IS GOING TO SPAWN FOR THE SECOND TIME 
		}
	}
}