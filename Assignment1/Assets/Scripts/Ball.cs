using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float _mult;
    [SerializeField]
    private TMP_Text _multText = null;
    public float Mult { get { return _mult; } }
    public void AddMult(float mult)
    {
        _mult += mult;
    }
    public void SetMult(float value)
    {
        _mult = value;
    }

    private void Update()
    {

        if (_mult < 0f)
        {
            _mult = 0f;
        }
        UpdateMultText();
    }
    private void UpdateMultText()
    {
        _multText.text = $"{_mult}";
    }
}
