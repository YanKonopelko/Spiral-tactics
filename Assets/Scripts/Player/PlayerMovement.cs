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

    public static Action onStaminaEnd;

    private Vector3 startPos;


    private void Start()
    {
        startPos = transform.position;
        isStay = false;
        UIManager.onChangedVerDir += VerMovementChange;
        UIManager.onChangedHorDir += HorMovementChange;
        rigidBody = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }
    private void Update()
    {
        if (dir != new Vector3(0, 0, 0) && isStay == false && player.curStamina > 0)
        {
            rigidBody.MovePosition(transform.position + dir * movementSpeed);
            player.curStamina -= 5 * Time.deltaTime;
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
        if (Vector3.Distance(transform.position, startPos) > 1000)
        {
            player.Fruits();
            SceneManager.LoadScene(0);
        }
    }

}
