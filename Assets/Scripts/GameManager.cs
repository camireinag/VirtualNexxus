using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text txtTotalEnemiesKilled;
    public int totalKills;
    public GameObject enemyContainer;
    private float stringTime;
    public float totalTime;
    public float minutes;
    public Text text;
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        stringTime = totalTime;
        instance = this;
        totalKills = enemyContainer.GetComponentsInChildren<EnemyController>().Length;
        txtTotalEnemiesKilled.text = "Total Enemies: " + totalKills.ToString();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        totalTime -= Time.deltaTime;
        minutes = (int)(totalTime / 60);
        seconds = (int)(totalTime % 60);
        text.text = minutes.ToString()+ ":" + seconds.ToString();

        if(totalTime<0)
        {
            text.text = "00:00";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void AddEnemyKill()
    {
        totalKills --;
        txtTotalEnemiesKilled.text = "Total Enemies: " + totalKills.ToString();
    }


}
