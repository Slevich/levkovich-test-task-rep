using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollecter : MonoBehaviour
{
    #region Поля
    //Переменная, содержащая количество собранных обычных монеток.
    private static int earnedSimpleCoins;
    //Переменная, содержащая количество собранных красных монеток.
    private static int earnedRedCoins;
    #endregion

    #region Свойства
    //Свойства для получения значений.
    private PlayerUIUpdater uIUpdater => GetComponent<PlayerUIUpdater>();
    private GameChecker gameChecker => GetComponent<GameChecker>();
    private LevelEnder levelEnder => GetComponent<LevelEnder>();
    public int EarnedSimpleCoins => earnedSimpleCoins;
    public int EarnedRedCoins => earnedRedCoins;
    #endregion

    #region Методы
    /* Метод увеличивает количество монеток, обновляет счетчики на UI.
     * Также проверяется достигнута ли цель уровня. Если да - вызываем метод конца уровня.
     */
    public void IncreaseSimpleCoins(bool isRedCoin)
    {
        if (isRedCoin) earnedRedCoins++;
        else earnedSimpleCoins++;

        uIUpdater.UpdateCoinCounts(earnedSimpleCoins, earnedRedCoins);

        if (gameChecker.CheckCoinsEarn(earnedSimpleCoins, earnedRedCoins))
        {
            levelEnder.OnGameEnd();
        }
    }
    #endregion
}
