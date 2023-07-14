using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static long Money;
    public long startMoney = 500;

    public static int Lives;
    public int startLives = 100;

    public static int Rounds;

    private void Awake()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }
}
