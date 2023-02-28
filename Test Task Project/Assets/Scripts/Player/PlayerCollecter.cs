using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollecter : MonoBehaviour
{
    #region ����
    //����������, ���������� ���������� ��������� ������� �������.
    private static int earnedSimpleCoins;
    //����������, ���������� ���������� ��������� ������� �������.
    private static int earnedRedCoins;
    #endregion

    #region ��������
    //�������� ��� ��������� ��������.
    private PlayerUIUpdater uIUpdater => GetComponent<PlayerUIUpdater>();
    private GameChecker gameChecker => GetComponent<GameChecker>();
    private LevelEnder levelEnder => GetComponent<LevelEnder>();
    public int EarnedSimpleCoins => earnedSimpleCoins;
    public int EarnedRedCoins => earnedRedCoins;
    #endregion

    #region ������
    /* ����� ����������� ���������� �������, ��������� �������� �� UI.
     * ����� ����������� ���������� �� ���� ������. ���� �� - �������� ����� ����� ������.
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
