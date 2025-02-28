using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject Bcontinue;
    [SerializeField] GameObject BMenu;
    [SerializeField] GameObject BRespawn;
    [SerializeField] GameObject BPause;
    [SerializeField] GameObject BNext;
    [SerializeField] GameObject BRestart;
    private void Start()
    {
        Bcontinue.SetActive(false);
        BMenu.SetActive(false);
        BRespawn.SetActive(false);
        BNext.SetActive(false);
        BRestart.SetActive(false);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Bcontinue.SetActive(true);
        BMenu.SetActive(true);
        BRespawn.SetActive(false);
        BNext.SetActive(false);
        Time.timeScale = 0;
    }
    public void Respawn()
    {
        //BMenu.SetActive(false);
        //BRespawn.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Continue()
    {
        Bcontinue.SetActive(false);
        BMenu.SetActive(false);
        BNext.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        BMenu.SetActive(false);
        BRespawn.SetActive(false);
        Bcontinue.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void Dead()
    {
        BPause.SetActive(false);
        BNext.SetActive(false);
        BMenu.SetActive(true);
        BRespawn.SetActive(true);
        Time.timeScale = 0;
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Wictory()
    {
        Time.timeScale = 0;
        Bcontinue.SetActive(false);
        BPause.SetActive(false);
        BMenu.SetActive(true);
        BRespawn.SetActive(false);
        BNext.SetActive(true);
        BRestart.SetActive(true);
    }
}
