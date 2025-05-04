using UnityEngine;
using UnityEngine.SceneManagement;

public class NewButtonContoller : MonoBehaviour
{
    public GameObject PauseMenuScreen;
    public GameObject PauseButton;
    private bool EndState = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !EndState)
        {
            TogglePause();
            AudioManager.instance.Play("Click");
        }
    }

    public void TogglePause()
    {
        bool isPausing = !PauseMenuScreen.activeSelf;

        PauseMenuScreen.SetActive(isPausing);
        PauseButton.SetActive(!isPausing);

        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.MyTurn = !isPausing;
    }

    public void Respawn()
    {
        Actor.ClearAll();//�� �������� ����� ��������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.Play("Click");
    }

    public void Menu()
    {
        Actor.ClearAll();//
        SceneManager.LoadScene(0);
        AudioManager.instance.Play("Click");
    }

    public void Next()
    {
        Actor.ClearAll();//
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