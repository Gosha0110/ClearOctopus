using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public int hp = 5;
    public static bool isDead = false;

    public GameObject Player;
    public Transform Chain;
    public GameObject[] Hearts;

    public Image ChainBar;
    private float fill;

    private bool inChain = false;

    public GameObject HealtBar;

    public GameObject PanelDead;

    public Text CoinText;
    public static int Coins;

    private bool isTry = false;
    private int isArise;

    private int isShield;
    private bool isCanTD = true;
    public GameObject Shield;

    public int is_Health;

    public int SpareLives = 0;

    public void RepeatGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Arise()
    {
        if (isTry == false && isArise == 10)
        {
            hp -= hp;
            hp += 3;
            Hearts[0].SetActive(true);
            Hearts[1].SetActive(true);
            Hearts[2].SetActive(true);
            PanelDead.SetActive(false);
            isDead = false;
            isTry = true;
            fill = 0.5f;
            StartCoroutine(CheckCoins());
        }
    }

    public void Start()
    {
        Coins = 0;
        isDead = false;
        fill = 0.5f;
        is_Health = Ekonomic.isHaveHealth;
        StartCoroutine(TimeChain());
        StartCoroutine(CheckCoins());
        StartCoroutine(CheckDead());

        if (is_Health == 10)
        {
            SpareLives = 5;
            StartCoroutine(CheckHealth());
        }
    }

    public void Update()
    {
        ChainBar.fillAmount = fill;
        CoinText.text = Coins + "";

        isArise = Ekonomic.isCanArise;
        isShield = Ekonomic.isHaveShield;
        is_Health = Ekonomic.isHaveHealth;

        if (fill <= 0)
        {
            hp -= hp;
        }
        
        if (Player.transform.position == Chain.position)
        {
            inChain = true;
        }

        else
        {
            inChain = false;
        }
    }

    private void Repeat()
    {
        StartCoroutine(TimeChain());
    }

    private void Repeat2()
    {
        StartCoroutine(CheckCoins());
    }

    private void Repeat3()
    {
        StartCoroutine(CheckDead());
    }

    private void Repeat4()
    {
        StartCoroutine(CheckHealth());
    }

    private IEnumerator CheckHealth()
    {
        if (is_Health == 10 && SpareLives > 0)
        {
            yield return new WaitForSeconds(40f);
            SpareLives -= 1;
            hp += 1;
        }
        Repeat4();
    }

    private IEnumerator CheckDead()
    {
        yield return new WaitForSeconds(0.5f);
        if (hp <= 0) 
        {
            PanelDead.SetActive(true);
            isDead = true;
            hp = 0;
        }
        Repeat3();
    }

    private IEnumerator CheckCoins()
    {
        if (isDead == false)
        {
            yield return new WaitForSeconds(0.5f);
            Coins += 1;
        }
        Repeat2();
    }

    private IEnumerator TimeChain()
    {
        if (Player.transform.position == Chain.position)
        {
            yield return new WaitForSeconds(0.5f);
            fill -= 0.02f;
        }

        else
        {
            if (fill < 1f)
            {
                yield return new WaitForSeconds(3f);
                fill += 0.02f;
            }

            else
            {
                fill -= fill;           
            }
        }
        Repeat();
    }

    private IEnumerator TimeTD()
    {
        yield return new WaitForSeconds(1f);
        isCanTD = true;
        Shield.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Litter" && inChain == false && isCanTD == true)
        {
            hp -= 1;
            fill -= 0.05f;
            Destroy(coll.gameObject);
            Hearts[hp].SetActive(false);

            if (isShield == 10 && isCanTD == true)
            {
                isCanTD = false;
                Shield.SetActive(true);
                StartCoroutine(TimeTD());
            }

            else if (isShield == 10 && isCanTD == false)
            {
                isCanTD = true;
                Destroy(coll.gameObject);
            }
        }
    }
}