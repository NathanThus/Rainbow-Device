using DG.Tweening;
using TMPro;
using UnityEngine;

public enum CurrentColor
{
    Black,
    Red,
    Green,
    Blue
}

public class ColourSwitcher : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _time;

    private CurrentColor currentColor = CurrentColor.Black;
    private bool _isTouching = false;
    private bool _previousState = false;
    // Update is called once per frame
    private void Start()
    {
        _sprite.material.color = Color.black;
    }

    void Update()
    {
        _isTouching = Input.touchCount > 0;
        if(_isTouching && !_previousState)
        {
            SwitchColour();
            _previousState = true;
        }
        else if(!_isTouching)
        {
            _previousState = false;
        }
    }

    private void SwitchColour()
    {
        switch (currentColor)
        {
            case CurrentColor.Black:
            _sprite.material.DOColor(Color.black,_time);
            currentColor = CurrentColor.Red;
                break;
            case CurrentColor.Red:
            _sprite.material.DOColor(Color.red,_time);
            currentColor = CurrentColor.Green;
                break;
            case CurrentColor.Green:
            _sprite.material.DOColor(Color.green,_time);
            _text.DOColor(Color.black, _time);
            currentColor = CurrentColor.Blue;
                break;
            case CurrentColor.Blue:
            _sprite.material.DOColor(Color.blue,_time);
            _text.DOColor(Color.white, _time);
            currentColor = CurrentColor.Black;
                break;
        }

    }
}
