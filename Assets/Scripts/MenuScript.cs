using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private int Coins;

    public GameObject ShopPanel;

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Shop()
    {
        ShopPanel.SetActive(!ShopPanel.active);
    }
}