using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DamageEffect : MonoBehaviour, IObserver
{

    #region PrivateData

    private PostProcessVolume _postProcessVolume;

    private Vignette _vignette;

    private float _maxIntencity = 0.3f;

    private float _stepIntencity;

    private float _vignetteSpeed;

    private float _lostHealth;

    private float t;

    #endregion

    #region UnityMethods

    private void Start()
    {
        var data = GameObject.FindGameObjectWithTag("Data").GetComponent<CharacterData>();
        data.AddObserver(this);
        _stepIntencity = _maxIntencity / 100;
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _vignette);
    }

    private void Update()
    {
        if(_vignette.intensity.value != _lostHealth)
        {
            _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, _lostHealth * _stepIntencity, t);
            t += Time.deltaTime / _vignetteSpeed;
        }
    }

    #endregion

    #region IObserver

    void IObserver.Update(object _object)
    {
        var characterData = (CharacterData)_object;
        _lostHealth = characterData.MaxHealth - characterData.Health;
    }

    #endregion
}
