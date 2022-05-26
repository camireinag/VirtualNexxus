using UnityEngine;
using System.Collections;


public class EnemyController : MonoBehaviour
{
	NavMeshAgent agent; //Saber donde se mueve el enemigo por el mapa
	public Transform target; //Posición del target
	float distanceToTarget; //Distancia del target
	float chaseTime; //Tiempo de seguir
	public float distanceToChase = 10f; //Distancia hasta la que hace seguimiento
	public float chaseInterval = 2f; //Intervalo de seguimiento
									 // Use this for initialization
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();  //Se obtiene el navmesh
		chaseTime = chaseInterval; //Tiempo de chase es igual al intervalo del mismo
	}

	// Update is called once per frame
	void Update()
	{
		//Se actualizan las posiciones
		Vector3 posNoRot = new Vector3(target.position.x, transform.position.y, target.position.z);
		transform.LookAt(posNoRot);
		distanceToTarget = Vector3.Distance(transform.position, target.position);
		Chase();
	}
	void Chase() //Funcion para seguir al target
	{
		chaseTime -= Time.deltaTime;
		if (chaseTime < 0)
		{
			if (distanceToTarget > distanceToChase)
			{
				agent.SetDestination(target.position);
				agent.stoppingDistance = distanceToChase;
				chaseTime = chaseInterval;

			}
		}
	}
}