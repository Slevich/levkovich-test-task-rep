using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChecker : MonoBehaviour
{
    #region ����
    [Header("CoinSpawner component")]
    [SerializeField] private CoinSpawner coinSpawner;
    #endregion

    #region ������
    //����� ���������, ���������� �� ���� ������. ���� �� - ���������� true, ���� ��� - false.
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
