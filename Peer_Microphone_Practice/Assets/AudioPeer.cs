using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioPeer : MonoBehaviour
{
    AudioSource _audioSource;

    public AudioClip _audioClip;
    public bool _useMicrophone;
    public string _selectedDevice;
    //����ũ ��ġ�� 1���̸� 0 �� ����̽��� ���������
    //���� �������� ����̽��� �ִٸ� �����ؾ� �ϱ� ������ 
    public AudioMixerGroup _mixerGroupMicrophone, _mixerGroupMaster;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_useMicrophone)
        {
            if (Microphone.devices.Length > 0)//����ũ�� �������
            {
                _selectedDevice = Microphone.devices[0].ToString();
                _audioSource.outputAudioMixerGroup = _mixerGroupMicrophone;
                _audioSource.clip = Microphone.Start(_selectedDevice, true, 10, AudioSettings.outputSampleRate);
                //outputSampleRate = �⺻������ ���ļ��� 44100�� ��������� ���ļ��� �ٸ��� �ڵ������� ����ǵ��� 
                //AudioSettings.outputSampleRate�� Ȱ���Ѵ�.
            }
            else
            {
                _useMicrophone = false;
            }

        }
        if (!_useMicrophone)
        {
            _audioSource.outputAudioMixerGroup = _mixerGroupMaster;
            _audioSource.clip = _audioClip;
        }
        _audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
