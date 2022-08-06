using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameplayScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private string[] keys;
    void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = LocalizationManager.instance.GetLocalizedValue(keys[i]);
        }
    }
    public void BackToMenu()
    {
        if (SoundManager.instance)
            SoundManager.PlaySound(SoundManager.instance.BUTTONSOUND);
        SceneManager.LoadScene(0);
    }
}
