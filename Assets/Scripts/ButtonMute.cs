using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonMute : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    
    [SerializeField] private AudioMixerGroup _mixer;

    private Button _button;
    private bool _isMuted = false;
    private float _minVolume = -80;
    private float _maxVolume = 0;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Mute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Mute);
    }

    private void Mute()
    {
        float volume;

        if (_isMuted)
        {
            volume = _maxVolume;
            _isMuted = false;
        }
        else
        {
            volume = _minVolume;
            _isMuted = true;
        }

        _mixer.audioMixer.SetFloat(MasterVolume, volume);
    }
}
