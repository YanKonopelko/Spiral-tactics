using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moveButtonText;
    [SerializeField] private TextMeshProUGUI bulletText;
    [SerializeField] private Image staminaSprite;

    public static Action<int> onChangedVerDir;
    public static Action<int> onChangedHorDir;

    [SerializeField]private Player player;

    private bool isPaused = false;
    [SerializeField] private GameObject pausedPanel;
    private void Start()
    {
        Player.onShot += BulletChange;
        PlayerMovement.onStaminaEnd += ChangeMoveState;
        bulletText.text = player.curBullet.ToString();
    }

    private void Update()
    {
        //���������� ��������� ������������
        staminaSprite.fillAmount = player.curStamina / player.maxStamina;
    }

    //�������� ������ �������� ������
    public void ChangeMoveState()
    {
        if (moveButtonText.text == "GO")
        {
            onChangedHorDir.Invoke(1);
            moveButtonText.text = "Hold";
        }
        else
        {
            onChangedHorDir.Invoke(0);
            moveButtonText.text = "GO";
        }
    }
    public void ArrowClick(int value ) {
        onChangedVerDir.Invoke(value);
    }
    public void ArrowUnClick()
    {
        onChangedVerDir.Invoke(0);
    }

    public void Pause()
    {
        isPaused = !isPaused;
        pausedPanel.SetActive(isPaused);
        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    private void BulletChange()
    {
        //���������� ������� ���-�� ������
        bulletText.text = player.curBullet.ToString();
    }
}
