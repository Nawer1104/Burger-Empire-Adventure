using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buyer : MonoBehaviour
{
    private Transform PosPoint;

    private int burgerWannaBuy = 0;

    private bool isReachPos = false;

    public TextMeshProUGUI text;

    private Animator anim;

    private void Awake()
    {
        PosPoint = GameManager.Instance.PosPoint;
        anim = GetComponent<Animator>();
        burgerWannaBuy = Random.Range(1, 4);

        text.SetText(burgerWannaBuy.ToString());
    }

    private void Update()
    {
        if (isReachPos) return;

        transform.position = Vector3.MoveTowards(transform.position, PosPoint.position, 2 * Time.deltaTime);

        if (Vector3.Distance(transform.position, PosPoint.position) <= 0.1)
        {
            isReachPos = true;
            anim.SetTrigger("Show");
        }
    }

    public void GetBurger()
    {
        burgerWannaBuy--;
        text.SetText(burgerWannaBuy.ToString());
        if (burgerWannaBuy == 0)
        {
            gameObject.SetActive(false);
            GameManager.Instance.SpawnBuyer();
        }
    }
}
