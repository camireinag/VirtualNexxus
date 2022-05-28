using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlEscenas : MonoBehaviour 
{
    public enum Levels 
    {
        FirstPart = 0, SecondPart = 1, Menu = 2, Game = 3, GameCompleted = 4, GameOver = 5
    }
    public void CambiarEscena(Levels level) 
    {
        SceneManager.LoadScene((int)level);
    }
    public void CambiarEscena(int indice)
    {
        SceneManager.LoadScene(indice);
    }
    public static void CambiarEscenaStatic(Levels level) 
    {
        SceneManager.LoadScene((int)level);
    }
}
