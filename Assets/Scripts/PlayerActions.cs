using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour, IDamage
{
	public Transform posGun;
	public Transform cam;
	public GameObject bulletPrefab;

	public LayerMask ignoreLayer;

	RaycastHit hit;
	public int life=10;

	public GameObject damageEffect;
	public float saveInterval = 0.5f;
	float saveTime;
	WaitForSeconds wait;

	public AudioClip sonidoDisparo;
	AudioSource audioS;

	void Start()
	{
		damageEffect.SetActive(false);
		saveTime = 0.0f;
		//CanvasController.instance.AddTextHp(life);
		wait = new WaitForSeconds(0.2f);
		audioS = GetComponent<AudioSource>();              
	}

	private void Update()
	{
		Debug.DrawRay(cam.position, cam.forward*100f, Color.red);
		Debug.DrawRay(posGun.position, cam.forward * 100f, Color.blue);

		if (Input.GetMouseButtonDown(0))
		{
			Vector3 direction = cam.TransformDirection(new Vector3(0,0, 1));
			audioS.PlayOneShot(sonidoDisparo);

			GameObject bulletObj = ObjectPollingManager.instance.GetBullet(true);
			bulletObj.transform.position = posGun.position;
			if(Physics.Raycast(cam.position, direction, out hit, Mathf.Infinity, ~ignoreLayer))
			{
				bulletObj.transform.LookAt(hit.point);
			}
			else
			{
				Vector3 dir = cam.position + direction * 10f;
				bulletObj.transform.LookAt(dir);
			}

		}
		saveTime -= Time.deltaTime;

		if(life <= 0)
		{
			//SceneManager.LoadScene("Perder");
		}
	}

	public bool DoDamage(int vld, bool isPlayer)
	{
		Debug.Log("He recibido dano = " + vld+ " isPlayer = " +isPlayer);
		if (isPlayer == true) return false;
		else
		{
			if (saveTime <= 0)
			{
				life -= vld;
				//CanvasController.instance.AddTextHp(life);
				StartCoroutine(Effect());
			}
		}
		return true;
	}

	IEnumerator Effect()
	{
		saveTime = saveInterval;
		damageEffect.SetActive(true);
		yield return wait;
		damageEffect.SetActive(false);
	}
}
