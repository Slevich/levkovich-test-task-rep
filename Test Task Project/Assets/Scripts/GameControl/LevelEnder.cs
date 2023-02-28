using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnder : MonoBehaviour
{
    #region Поля
    [Header("Game object with level screen")]
    [SerializeField] private GameObject levelScreen;
    [Header("Game object with end screen")]
    [SerializeField] private GameObject endScreen;
    [Header("The time after which the current level is restarted")]
    [SerializeField] private float timerBeforeRestart;
    #endregion

    #region Методы
    //ПроверяемЮ чтобы установленное время не было меньше 0.
    private void OnValidate()
    {
        if (timerBeforeRestart < 0) timerBeforeRestart = 0;
    }

    //В Awake возвращаем timeScale к единице.
    private void Awake()
    {
        Time.timeScale = 1;
    }

    /* Метод скрывает объект с экраном уровня, активирует экран окончания.
     * Отключаем возможность осматриваться при помощи мыши.
     * TimeScale ставим в 0. Запускаем корутину.
     */
    public void OnGameEnd()
    {
        levelScreen.SetActive(false);
        endScreen.SetActive(true);
        GetComponent<StarterAssets.StarterAssetsInputs>().cursorInputForLook = false;
        Time.timeScale = 0;
        StartCoroutine(RestartLevelByTime());
    }

    //Корутина перезапускает через промежуток времени текущую сцену.
    private IEnumerator RestartLevelByTime()
    {
        yield return new WaitForSecondsRealtime(timerBeforeRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}
