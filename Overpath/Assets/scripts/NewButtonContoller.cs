using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewButtonContoller : MonoBehaviour
{
    public void Respawn()
    {
        Actor.AllActors.Clear();//Не ломается после рестарта
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.Play("Click");
    }
    public void Menu()
    {
        Actor.AllActors.Clear();//
        SceneManager.LoadScene(0);
        AudioManager.instance.Play("Click");
    }
    public void Next()
    {
        Actor.AllActors.Clear();//
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.instance.Play("Click");
    }
    public void PauseGame()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.MyTurn = false;
        AudioManager.instance.Play("Click");
    }
    public void Continue()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.MyTurn = true;
        AudioManager.instance.Play("Click");
    }
    public void Exit()
    {
        Application.Quit();
    }
}