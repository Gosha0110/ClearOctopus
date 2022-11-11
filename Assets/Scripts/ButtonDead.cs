using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonDead : MonoBehaviour
{
    public void Repeat()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}