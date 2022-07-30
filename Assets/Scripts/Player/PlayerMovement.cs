using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Player player;

    [SerializeField] private float movementSpeed = 1;
    public static float addMovementSpeed = 0;
    [SerializeField] private Vector3 dir = new Vector3(0, 0, 0);
    public static bool isStay = false;

    //Событие вызываемое при 0 выносливости
    public static Action onStaminaEnd;

    private Vector3 startPos;

    private int finishDistance = 1000;

    private void Start()
    {
        startPos = transform.position;

        isStay = false;

        UIManager.onChangedVerDir += VerMovementChange;
        UIManager.onChangedHorDir += HorMovementChange;

        rigidBody = GetComponent<Rigidbody>();
        player = GetComponent<Player>();

        StartCoroutine(isEnd());
    }
    private void Update()
    {
        if (isStay == false && dir != new Vector3(0, 0, 0) )
        {
            if(player.curStamina > 5 * Time.deltaTime) {
                rigidBody.MovePosition(transform.position + dir * movementSpeed);
                player.curStamina -= 5 * Time.deltaTime;
            }
            else
                onStaminaEnd.Invoke();
        }
        else
        {
            if (player.curStamina < player.maxStamina)
                player.curStamina += player.staminaRegeneration * Time.deltaTime;
        }
    }
    private void HorMovementChange(int value)
    {
        dir.x = value;
    }
    private void VerMovementChange(int value)
    {
        dir.z = -value;
    }

    private IEnumerator isEnd()
    {
        yield return new WaitForSeconds(3);
        //Проверка на пройденное расстояние
        if (Vector3.Distance(transform.position, startPos) > finishDistance)
        {
            //Сохранение прогресса и вход в меню
            player.Fruits();
            SceneManager.LoadScene(0);
        }
        StartCoroutine(isEnd());
    }

}
