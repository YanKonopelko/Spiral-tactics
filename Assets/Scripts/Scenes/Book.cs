using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Book : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private string[] keys;

    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject[] buttons;

    private void Start()
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

    public void ChangePanel(int num)
    {
        foreach(GameObject panel in panels)
            panel.SetActive(false);

        panels[num].SetActive(true);

        foreach (GameObject button in buttons)
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(400,140);

        buttons[num].GetComponent<RectTransform>().sizeDelta = new Vector2(440, 150);

    }

}
