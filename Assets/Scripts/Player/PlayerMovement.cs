using UnityEngine;
using System.Collections;
using System;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Player player;

    [SerializeField] private float horizontalMovementspeed = 2;
    [SerializeField] private float verticalMovementSpeed = 1;
    [SerializeField] private int verticalMovement = 0;
    public static bool isStay = true;

    private Coroutine coroutine;
    public static Action onStaminaEnd;
    private void Start()
    {
        isStay = true;
        UIManager.onChangedVerMovement += VerMovementChange;
        UIManager.onMoveStart += StartMove;
        UIManager.onMoveStop += StopMove;
        rigidBody = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    private void StartMove()
    {
        if(coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(Move());
    }
    private void StopMove()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(StaminaRegeneration());
    }
    private void VerMovementChange(int value)
    {
        verticalMovement = value;
    }

    private IEnumerator Move()
    {
        yield return new WaitForFixedUpdate();
        if (player.curStamina > 0)
        {
            Vector3 pos = transform.position + new Vector3(horizontalMovementspeed * Time.deltaTime * (isStay?0:1), 0, verticalMovementSpeed * Time.deltaTime * verticalMovement * -1);
            player.curStamina -= 5 * Time.deltaTime;
            rigidBody.MovePosition(pos);
            coroutine = StartCoroutine(Move());
        }
        else{
            onStaminaEnd.Invoke();
        }
        
    }

    private IEnumerator StaminaRegeneration()
    {
        yield return new WaitForFixedUpdate();
        if (player.curStamina < player.maxStamina)
        {
            player.curStamina += 5 * Time.deltaTime;
            coroutine = StartCoroutine(StaminaRegeneration());
        }
    }
}
