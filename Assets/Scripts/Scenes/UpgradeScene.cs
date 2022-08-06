using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UpgradeScene : MonoBehaviour
{ 
    FruitManager manager;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private string[] keys;

    [SerializeField] private Sprite[] fruits; 
    [SerializeField] private GameObject upgradeButton;

    private int _upgradeNum = -1;
    private void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = LocalizationManager.instance.GetLocalizedValue(keys[i]);
        }
        manager = GetComponent<FruitManager>();
    }

    public void Upgrade()
    {
        if (SoundManager.instance)
            SoundManager.PlaySound(SoundManager.instance.BUTTONSOUND);
        // Проверяет наличие фруктов и тратих их на улучшение
        string fruit_1 = " ", fruit_2 = " ";
        switch (_upgradeNum)
        {
            case 0:
                fruit_1 = "blueFruit";
                fruit_2 = "greenFruit";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                    PlayerPrefs.SetInt("addMaxBullet", PlayerPrefs.GetInt("addMaxBullet" + 1));
                break;
            case 1:
                fruit_1 = "blueFruit";
                fruit_2 = "redFruit";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                    PlayerPrefs.SetFloat("addStaminaRegeneration", PlayerPrefs.GetFloat("addStaminaRegeneration" + 1));
                break;
            case 2:
                fruit_1 = "blueFruit";
                fruit_2 = "blueFruit";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                    PlayerPrefs.SetFloat("addCollectTime", PlayerPrefs.GetFloat("addCollectTime" )- 0.1f);
                break;
            case 3:
                fruit_1 = "redFruit";
                fruit_2 = "redFruit";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                    PlayerPrefs.SetFloat("addMaxStamina", PlayerPrefs.GetFloat("addMaxStamina") + 1);
                break;
            case 4:
                fruit_1 = "greenFruit";
                fruit_2 = "greenFruit";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                    PlayerPrefs.SetFloat("collAddCollectTime", PlayerPrefs.GetFloat("collAddCollectTime") - 0.1f);
                break;
            case 5:
                fruit_1 = "redFruit";
                fruit_2 = "greenFruit";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                {
                    int a = Random.Range(0, 5);
                    switch (a)
                    {
                        case 0:
                            PlayerPrefs.SetInt("addMaxBullet", PlayerPrefs.GetInt("addMaxBullet" + 1));
                            break;
                        case 1:
                            PlayerPrefs.SetFloat("addStaminaRegeneration", PlayerPrefs.GetFloat("addStaminaRegeneration" + 1));
                            break;
                        case 2:
                            PlayerPrefs.SetFloat("addCollectTime", PlayerPrefs.GetFloat("addCollectTime") - 0.1f);
                            break;
                        case 3:
                            PlayerPrefs.SetFloat("addMaxStamina", PlayerPrefs.GetFloat("addMaxStamina") + 1);
                            break;
                        case 4:
                            PlayerPrefs.SetFloat("collAddCollectTime", PlayerPrefs.GetFloat("collAddCollectTime") - 0.1f);
                            break;
                    }
                }
                break;
        }
        
    }

    public void ChooseUpgrade(int upgradeNum)
    {
        _upgradeNum = upgradeNum;
        int fr_1 = 0, fr_2 = 0;
        Debug.Log(upgradeNum);
        switch (upgradeNum)
        {
            case 0:
                fr_1 = 2;
                fr_2 = 1;
                break;
            case 1:
                fr_1 = 2;
                fr_2 = 0;
                break;
            case 2:
                fr_1 = 2;
                fr_2 = 2;
                break;
            case 3:
                fr_1 = 0;
                fr_2 = 0;
                break;
            case 4:
                fr_1 = 1;
                fr_2 = 1;
                break;
            case 5:
                fr_1 = 0;
                fr_2 = 1;
                break;
    }

        upgradeButton.transform.GetChild(0).GetComponent<Image>().sprite = fruits[fr_1];

        upgradeButton.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);

        upgradeButton.transform.GetChild(1).GetComponent<Image>().sprite = fruits[fr_2];

        upgradeButton.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 255);

    }

    public void ToMenu()
    {
        if (SoundManager.instance)
            SoundManager.PlaySound(SoundManager.instance.BUTTONSOUND);
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        text.text = manager.fruits["blueFruit"].ToString() + manager.fruits["greenFruit"].ToString() + manager.fruits["redFruit"].ToString();
    }
}
