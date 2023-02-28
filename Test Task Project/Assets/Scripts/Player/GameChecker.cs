using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChecker : MonoBehaviour
{
    #region Поля
    [Header("CoinSpawner component")]
    [SerializeField] private CoinSpawner coinSpawner;
    #endregion

    #region Методы
    //Метод проверяет, достигнуты ли цели уровня. Если да - возвращает true, если нет - false.
    public bool CheckCoinsEarn(int SimpleCoinsAmount, int RedCoinsAmount)
    {
        if ((SimpleCoinsAmount == coinSpawner.SimpleCoinsCount) || (RedCoinsAmount > 0))
        {
            return true;
        }
        else return false;
    }
    #endregion
}
