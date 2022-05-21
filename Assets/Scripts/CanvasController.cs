using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour
{
	//public Text txtHp;
	public static CanvasController instance;

	private void Awake()
	{
		instance = this;
	}
	public void AddTextHp(int vld)
	{
		//txtHp.text= "HP// " + vld.ToString();
	}
}