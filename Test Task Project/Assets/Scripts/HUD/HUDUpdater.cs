using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDUpdater : MonoBehaviour
{
    #region Поля
    [Header("TMPRO UGUI with amount of simple coins")]
    [SerializeField] private TextMeshProUGUI allSimpleCoinsText;
    [Header("TMPRO UGUI with amount of red coins")]
    [SerializeField] private TextMeshProUGUI allRedCoinsText;
    [Header("CoinSpawner component")]
    [SerializeField] private CoinSpawner coinSpawner;
    #endregion

    #region Методы
    //На старте обновляем максимальное количество монеток в UI.
    private void Start()
    {
        UpdateTotalCoinsCounts(coinSpawner.SimpleCoinsCount, coinSpawner.RedCoinsCount);
    }

    //Метод передает значения в текст на UI.
    private void UpdateTotalCoinsCounts(int AllSimpleCoins, int AllRedCoins)
    {
        allSimpleCoinsText.text = AllSimpleCoins.ToString();
        allRedCoinsText.text = AllRedCoins.ToString();
    }
    #endregion
}
