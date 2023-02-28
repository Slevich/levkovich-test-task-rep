using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnder : MonoBehaviour
{
    #region ����
    [Header("Game object with level screen")]
    [SerializeField] private GameObject levelScreen;
    [Header("Game object with end screen")]
    [SerializeField] private GameObject endScreen;
    [Header("The time after which the current level is restarted")]
    [SerializeField] private float timerBeforeRestart;
    #endregion

    #region ������
    //���������� ����� ������������� ����� �� ���� ������ 0.
    private void OnValidate()
    {
        if (timerBeforeRestart < 0) timerBeforeRestart = 0;
    }

    //� Awake ���������� timeScale � �������.
    private void Awake()
    {
        Time.timeScale = 1;
    }

    /* ����� �������� ������ � ������� ������, ���������� ����� ���������.
     * ��������� ����������� ������������� ��� ������ ����.
     * TimeScale ������ � 0. ��������� ��������.
     */
    public void OnGameEnd()
    {
        levelScreen.SetActive(false);
        endScreen.SetActive(true);
        GetComponent<StarterAssets.StarterAssetsInputs>().cursorInputForLook = false;
        Time.timeScale = 0;
        StartCoroutine(RestartLevelByTime());
    }

    //�������� ������������� ����� ���������� ������� ������� �����.
    private IEnumerator RestartLevelByTime()
    {
        yield return new WaitForSecondsRealtime(timerBeforeRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}
