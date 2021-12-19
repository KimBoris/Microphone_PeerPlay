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
    //마이크 장치가 1개이면 0 번 디바이스를 사용하지만
    //만약 여러개의 디바이스가 있다면 선택해야 하기 때문에 
    public AudioMixerGroup _mixerGroupMicrophone, _mixerGroupMaster;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_useMicrophone)
        {
            if (Microphone.devices.Length > 0)//마이크가 있을경우
            {
                _selectedDevice = Microphone.devices[0].ToString();
                _audioSource.outputAudioMixerGroup = _mixerGroupMicrophone;
                _audioSource.clip = Microphone.Start(_selectedDevice, true, 10, AudioSettings.outputSampleRate);
                //outputSampleRate = 기본적으로 주파수는 44100을 사용하지만 주파수가 다를때 자동적으로 적용되도록 
                //AudioSettings.outputSampleRate를 활용한다.
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
