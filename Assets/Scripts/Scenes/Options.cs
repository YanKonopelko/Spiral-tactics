using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Options : MonoBehaviour
{
    public Slider vfxSlider;
    public Slider musicSlider;

    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private string[] keys;

    private void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = LocalizationManager.instance.GetLocalizedValue(keys[i]);
        }
        if (MusicManager.instance)
        {
            vfxSlider.value = (PlayerPrefs.HasKey("VFX_VOLUME")) ? PlayerPrefs.GetFloat("VFX_VOLUME") : SoundManager.volume;
            musicSlider.value = (PlayerPrefs.HasKey("MUSIC_VOLUME")) ? PlayerPrefs.GetFloat("MUSIC_VOLUME") : MusicManager.volume;
        }
    }
    public void BackToMenu()
    {
        if (SoundManager.instance)
            SoundManager.PlaySound(SoundManager.instance.BUTTONSOUND);
        SceneManager.LoadScene(0);
    }

    public void SliderVFXChanged(Slider slider)
    {
        PlayerPrefs.SetFloat("VFX_VOLUME", vfxSlider.value);
        SoundManager.ChangeVolume(slider.value);
    }

    public void SliderMusicChanged(Slider slider)
    {
        PlayerPrefs.SetFloat("MUSIC_VOLUME", musicSlider.value);
        MusicManager.ChangeVolume(slider.value);
    }
    public void ChangeLanuage(string value)
    {
        if (SoundManager.instance)
            SoundManager.PlaySound(SoundManager.instance.BUTTONSOUND);
        LocalizationManager.instance.CurrentLanguage = value;
        SceneManager.LoadScene(3);
    }
}
