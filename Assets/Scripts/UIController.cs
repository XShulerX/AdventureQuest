using UnityEngine;

public class UIController : MonoBehaviour, IObserver
{

    #region Fields

    private float _maxHealth;
    private float _currentHealth;

    #endregion

    #region UnityMethods

    private void Start()
    {
        var data = GameObject.FindGameObjectWithTag("Data").GetComponent<CharacterData>();
        data.AddObserver(this);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0f, 0f, 100f, 20f),"Health " + _currentHealth.ToString());
    }


    #endregion

    #region IObsrever

    void IObserver.Update(object _object)
    {
        var characterData = (CharacterData)_object;
        if (_maxHealth != characterData.MaxHealth)
        {
            _maxHealth = characterData.MaxHealth;
        }
        if (_currentHealth != characterData.Health)
        {
            _currentHealth = characterData.Health;
        }
    }

    #endregion

}
