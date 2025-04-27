using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuEvents : MonoBehaviour
{
    public Slider volumeslider;
    public Slider MusicSlider;
    public AudioMixer mixer;
    public AudioMixer mixermusic;
    private float value;
    private float valuemusic;
    private void Start()
    {
        mixer.GetFloat("MasterVolume", out value);
        volumeslider.value = value;
        mixermusic.GetFloat("Music", out valuemusic);
        MusicSlider.value = valuemusic;
    }
    public void SetVolume()
    {
        mixer.SetFloat("MasterVolume", volumeslider.value);
    }
    public void SetMusic()
    {
        mixermusic.SetFloat("Music", MusicSlider.value);
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
        AudioManager.instance.Play("Click");
    }
}