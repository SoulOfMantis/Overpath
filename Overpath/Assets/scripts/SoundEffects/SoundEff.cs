using UnityEngine;

public class SoundEff : MonoBehaviour
{
    public void ClickButton()
    {
        AudioManager.instance.Play("Click");
    }
}
