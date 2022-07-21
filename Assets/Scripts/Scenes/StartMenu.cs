using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private void Start()
    {
        if (MusicManager.instance)
            MusicManager.ChangeMusic(MusicManager.instance.mainMenuMusic);
    }
    public void ToGameplayScene()
    {
        if (SoundManager.instance)
            SoundManager.PlaySound(SoundManager.instance.BUTTONSOUND);
        SceneManager.LoadScene(1);
    }
    public void ToUpgradeScene()
    {
        if (SoundManager.instance)
            SoundManager.PlaySound(SoundManager.instance.BUTTONSOUND);
        SceneManager.LoadScene(2);
    }

}
