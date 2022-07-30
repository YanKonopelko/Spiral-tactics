using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UpgradeScene : MonoBehaviour
{ 
    FruitManager manager;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private string[] keys;

    private void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = LocalizationManager.instance.GetLocalizedValue(keys[i]);
        }
        manager = GetComponent<FruitManager>();
    }

    public void Upgrade(int number)
    {
        if (SoundManager.instance)
            SoundManager.PlaySound(SoundManager.instance.BUTTONSOUND);
        // Проверяет наличие фруктов и тратих их на улучшение
        string fruit_1 = " ", fruit_2 = " ";
        switch (number)
        {
            case 0:
                fruit_1 = "blue";
                fruit_2 = "yellow";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                    PlayerPrefs.SetInt("addMaxBullet", PlayerPrefs.GetInt("addMaxBullet" + 1));
                break;
            case 1:
                fruit_1 = "blue";
                fruit_2 = "red";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                    PlayerPrefs.SetFloat("addStaminaRegeneration", PlayerPrefs.GetFloat("addStaminaRegeneration" + 1));
                break;
            case 2:
                fruit_1 = "blue";
                fruit_2 = "blue";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                    PlayerPrefs.SetFloat("addCollectTime", PlayerPrefs.GetFloat("addCollectTime" )- 0.1f);
                break;
            case 3:
                fruit_1 = "red";
                fruit_2 = "red";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                    PlayerPrefs.SetFloat("addMaxStamina", PlayerPrefs.GetFloat("addMaxStamina") + 1);
                break;
            case 4:
                fruit_1 = "yellow";
                fruit_2 = "yellow";
                if (manager.FruitsSubstr(fruit_1, fruit_2))
                    PlayerPrefs.SetFloat("collAddCollectTime", PlayerPrefs.GetFloat("collAddCollectTime") - 0.1f);
                break;
            case 5:
                fruit_1 = "red";
                fruit_2 = "yellow";
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

    public void ToMenu()
    {
        if (SoundManager.instance)
            SoundManager.PlaySound(SoundManager.instance.BUTTONSOUND);
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        text.text = manager.fruits["blue"].ToString() + manager.fruits["red"].ToString() + manager.fruits["yellow"].ToString();
    }
}
