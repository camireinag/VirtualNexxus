using UnityEngine;
using System.Collections;

public class Sway : MonoBehaviour
{
	private Quaternion originLocalRotation;
	// Start is called before the first frame update
	private void Start()
	{
		originLocalRotation = transform.localRotation;
	}

	// Update is called once per frame
	void Update()
	{
		updateSway();
	}

	private void updateSway()
	{
		float t_xLookInput = Input.GetAxis("Mouse X");
		float t_yLookInput = Input.GetAxis("Mouse Y");

		//Calcular la rotación del arma
		Quaternion t_xAngleAdjustment = Quaternion.AngleAxis(-t_xLookInput * 1.45f, Vector3.right); //el valor se puede incrementar si se desea que sea más notable la rotación del arma
		Quaternion t_yAngleAdjustment = Quaternion.AngleAxis(-t_yLookInput * 1.45f, Vector3.right);
		Quaternion t_targerRotation = originLocalRotation * t_xAngleAdjustment * t_yAngleAdjustment;

		//Rotar de acuerdo al tarjet
		transform.localRotation = Quaternion.Lerp(transform.localRotation, t_targerRotation, Time.deltaTime * 10f);
	}
}
