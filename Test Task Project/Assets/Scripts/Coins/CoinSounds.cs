using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSounds : MonoBehaviour
{
    #region ��������
    //�������� ��� ��������� ��������� �����.
    private AudioSource soundsSource => GetComponentInChildren<AudioSource>();
    #endregion

    #region ������
    //����� ����������� �������� �����.
    public void PlayCoinSound()
    {
        soundsSource.Play();
    }
    #endregion
}
