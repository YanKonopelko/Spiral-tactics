using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class StartMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private string[] keys;

    private void Start()
    {
        for(int i =0; i <texts.Length; i++)
        {
            texts[i].text = LocalizationManager.instance.GetLocalizedValue(keys[i]);
        }
        if (MusicManager.instance)
            MusicManager.ChangeMusic(MusicManager.instance.mainMenuMusic);
    }
    public void ToGameplayScene()
    {
        ButtonSound();
        SceneManager.LoadScene(1);
    }
    public void ToUpgradeScene()
    {
        ButtonSound();
        SceneManager.LoadScene(2);
    }
    public void ToOptionsScene()
    {
        ButtonSound();
        SceneManager.LoadScene(3);
    }
    public void ToWiseBookScene()
    {
        ButtonSound();
        SceneManager.LoadScene(4);
    }
    public void Exit()
    {
        ButtonSound();
        Application.Quit();
    }
    private void ButtonSound() {
        if (SoundManager.instance)
            SoundManager.PlaySound(SoundManager.instance.BUTTONSOUND);
    }
}
