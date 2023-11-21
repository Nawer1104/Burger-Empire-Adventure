using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;

    public GameObject vfxBurgerCollected;
    public GameObject vfxSell;
    public GameObject burger;
    public bool isHaveBurger;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startPos = transform.position;

        isHaveBurger = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (isHaveBurger)
        {
            burger.gameObject.SetActive(true);
        }
        else
        {
            burger.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BurgerMachine"))
        {
            GameObject vfxCollect = Instantiate(vfxBurgerCollected, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfxCollect, 1f);
            isHaveBurger = true;
        }

        if (collision.gameObject.CompareTag("Buyer"))
        {
            if (isHaveBurger)
            {
                GameObject vfxCollect = Instantiate(vfxSell, transform.position, Quaternion.identity) as GameObject;
                Destroy(vfxCollect, 1f);
                collision.gameObject.GetComponent<Buyer>().GetBurger();
                isHaveBurger = false;
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector2.zero;
        }
    }
}