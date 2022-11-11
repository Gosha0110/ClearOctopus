using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform Player;

    public Transform PosCenter;
    public Transform PosLeft;
    public Transform PosRight;

    public Transform PosDown;

    private int ProgressPos = 2;

    public void MoveDown()
    {
        Player.position = PosDown.position;
    }

    public void MoveLeft()
    {
        if (ProgressPos == 2)
        {
            Player.position = PosLeft.position;
            ProgressPos = 1;
        }

        else if (ProgressPos == 3)
        {
            Player.position = PosCenter.position;
            ProgressPos = 2;
        }
    }

    public void MoveRight()
    {
        if (ProgressPos == 2)
        {
            Player.position = PosRight.position;
            ProgressPos = 3;
        }

        else if (ProgressPos == 1)
        {
            Player.position = PosCenter.position;
            ProgressPos = 2;
        }
    }
}