using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moveButtonText;
    [SerializeField] private TextMeshProUGUI bulletText;
    [SerializeField] private Image staminaSprite;

    public static Action<int> onChangedVerMovement;
    public static Action onMoveStart;
    public static Action onMoveStop;

    [SerializeField]private Player player;

    private bool isPaused = false;
    [SerializeField] private GameObject pausedPanel;
    private void Start()
    {
        Player.onShot += BulletChange;
        PlayerMovement.onStaminaEnd += ChangeMoveState;
        bulletText.text = player.curBullet.ToString();
    }

    private void FixedUpdate()
    {
        staminaSprite.fillAmount = player.curStamina / player.maxStamina;
    }


    public void ChangeMoveState()
    {
        PlayerMovement.isStay = !PlayerMovement.isStay;
        if (!PlayerMovement.isStay)
        {
            onMoveStart.Invoke();
            moveButtonText.text = "Hold";
        }
        else
        {
            onMoveStop.Invoke();
            moveButtonText.text = "Go";
        }
    }

    public void ArrowClick(int value ) {
        onChangedVerMovement.Invoke(value);
    }
    public void ArrowUnClick()
    {
        onChangedVerMovement.Invoke(0);
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
        bulletText.text = player.curBullet.ToString();
    }
}
