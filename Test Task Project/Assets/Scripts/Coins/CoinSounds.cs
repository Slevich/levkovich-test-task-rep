using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSounds : MonoBehaviour
{
    #region Свойства
    //Свойство для получения источника звука.
    private AudioSource soundsSource => GetComponentInChildren<AudioSource>();
    #endregion

    #region Методы
    //Метод проигрываем источник звука.
    public void PlayCoinSound()
    {
        soundsSource.Play();
    }
    #endregion
}
