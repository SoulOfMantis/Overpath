using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewButtonContoller : MonoBehaviour
{
    private Player player;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();    
    }
    public void Respawn()
    {
        Actor.AllActors.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Actor.AllActors.Clear();
        SceneManager.LoadScene(0);
    }
    public void Next()
    {
        Actor.AllActors.Clear();   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PauseGame()
    {
        player.MyTurn = false;
    }
    public void Continue()
    {
        player.MyTurn = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
