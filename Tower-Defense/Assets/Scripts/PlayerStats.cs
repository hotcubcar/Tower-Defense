using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int rounds;

    void Start()
    {
        rounds = 0;
        Money = startMoney;
        Lives = startLives;
    }
}
