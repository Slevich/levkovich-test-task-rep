using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIUpdater : MonoBehaviour
{
    #region ����
    [Header("TMPRO UGUI with current amount of simple coins")]
    [SerializeField] private TextMeshProUGUI currentSimpleCoinsText;
    [Header("TMPRO UGUI with current amount of red coins")]
    [SerializeField] private TextMeshProUGUI currentRedCoinsText;
    [Header("Game object with level screen.")]
    [SerializeField] private GameObject levelScreen;
    [Header("Game object with end screen.")]
    [SerializeField] private GameObject endScreen;
    #endregion

    #region ������
    //����� �������� �������� � ����� ��������� ������� �� UI.
    public void UpdateCoinCounts(int CurrentSimpleCoins, int CurrentRedCoins)
    {
        currentSimpleCoinsText.text = CurrentSimpleCoins.ToString();
        currentRedCoinsText.text = CurrentRedCoins.ToString();
    }
    #endregion
}
