using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicking : MonoBehaviour
{
    #region Поля
    [Header("Prefab with VFX, which spawn when player pick up a coin. ")]
    [SerializeField] private GameObject VFXPrefab;
    [Header("Whether the coin is red or not.")]
    [SerializeField] private bool isRedCoin;
    #endregion

    #region Методы
    /* При вхождении в триггер монетки, проверяем имеется ли компонент на коллайдере.
     * Если да, увеличиваем счетчик монеток, спавним эффект подбора, проигрываем звук и уничтожаем монетку.
     */
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<PlayerCollecter>(out PlayerCollecter playerCollecter))
        {
            playerCollecter.IncreaseSimpleCoins(isRedCoin);
            GameObject newVFXObject = Instantiate(VFXPrefab, transform.position, Quaternion.identity);
            collider.GetComponent<CoinSounds>().PlayCoinSound();
            Destroy(gameObject);
        }
    }
    #endregion
}