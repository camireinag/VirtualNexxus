using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour 
{
	[SerializeField] int min, seg;
	[SerializeField] Text tiempo;
	public bool enMarcha;
	public float restante;

	private void Awake() 
	{
	restante = (min *60) + seg;
	enMarcha = true;
	}
	// Update is called once per frame
	void Update () 
	{
        if (enMarcha)
        {
			restante -= Time.deltaTime;
			int tempMin = Mathf.FloorToInt(restante / 60);
			int tempSeg = Mathf.FloorToInt(restante % 60);
			tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
		}
		if (restante < 1)
		{
			enMarcha = true;
			ControlEscenas.CambiarEscenaStatic(ControlEscenas.Levels.GameCompleted);
		}
	}
}
