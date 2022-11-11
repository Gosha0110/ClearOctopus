using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ekonomic : MonoBehaviour
{
    public Text MenuCoinText;
    public static int MenuCoins;

    public static int isCanArise;
    public static int isHaveShield;
    public static int isHaveHealth;

    public bool isCanBuyA = true;
    public bool isCanBuyS = true;
    public bool isCanBuyH = true;

    public int[] Prises;

    public void Start()
    {
        MenuCoins += HealthPlayer.Coins;
        PlayerPrefs.SetInt("MenuCoins", MenuCoins);
    }

    public void Update()
    {
        PlayerPrefs.SetInt("MenuCoins", MenuCoins);
        MenuCoinText.text = MenuCoins + "";
    } 

    public void ShopArise()
    {
        if (MenuCoins >= Prises[0] && isCanBuyA == true)
        {
            isCanBuyA = false;
            MenuCoins -= Prises[0];
            isCanArise = 10;
            PlayerPrefs.SetInt("isCanArise", isCanArise);
            PlayerPrefs.SetInt("MenuCoins", MenuCoins);
        }
    }

    public void ShopShield()
    {
        if (MenuCoins >= Prises[1] && isCanBuyS == true)
        {
            isCanBuyS = false;
            MenuCoins -= Prises[1];
            isHaveShield = 10;
            PlayerPrefs.SetInt("isHaveShield", isHaveShield);
            PlayerPrefs.SetInt("MenuCoins", MenuCoins);
        }
    }

    public void ShopHealth()
    {
        if (MenuCoins >= Prises[2] && isCanBuyH == true)
        {
            isCanBuyH = false;
            MenuCoins -= Prises[2];
            isHaveHealth = 10;
            PlayerPrefs.SetInt("isHaveHealth", isHaveHealth);
            PlayerPrefs.SetInt("MenuCoins", MenuCoins);
        }
    }
}