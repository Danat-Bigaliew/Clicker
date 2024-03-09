using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinersOperation : MonoBehaviour
{
    [SerializeField] private float _oreMiningPerClick = 20;
    [SerializeField] public float _maximumAmountOreInBag = 100;
    [SerializeField] private int _numberOfClicksForLaunchPhrase = 60;
    [SerializeField] private int _clickCounter = 0;
    public Button _button { get; private set; }
    private MainAnimations _mainAnimation;
    private PlayerStatistics _playerStatistics;

    [SerializeField] private TextMeshProUGUI _oreCounter;

    private void Start()
    {
        _button = GetComponent<Button>();
        _mainAnimation = GetComponent<MainAnimations>();
        _playerStatistics = GetComponent<PlayerStatistics>();

        if (_button != null)
        {
            _button.onClick.AddListener(CheckingOreInBag);
        }
        else
        {
            Debug.LogError("Кнопка не найдена.");
        }

        if (_mainAnimation == null)
        {
            Debug.LogError("Что то явно не так");
        }

        _oreCounter.text = $"Руда: {_playerStatistics._oreInBag} / {_maximumAmountOreInBag}";
    }

    private void CheckingOreInBag()
    {
        if(_playerStatistics._oreInBag >= _maximumAmountOreInBag)
        {
            Debug.Log("Сумка переполнена");
        }
        else if(_playerStatistics._oreInBag < _maximumAmountOreInBag)
        {
            Debug.Log("Удар возможен");
            OnButtonClick();
        }
    }

    private void OnButtonClick()
    {
        if (_button != null && !_mainAnimation._isAnimationPlaying)
        {
            AnimatorStateInfo stateInfo = _mainAnimation._animator.GetCurrentAnimatorStateInfo(0);

            if (!_mainAnimation._isAnimationPlaying && stateInfo.IsName(_mainAnimation._nameAnimationIdle))
            {
                _mainAnimation._isAnimationPlaying = true;
                _button.interactable = false;
                //_clickProcessing.ChangeButton();
                StartCoroutine(_mainAnimation.PlayBlowAnimation(_button));
                ConsequenceOfTheClick();
            }
        }
        else
        {
            Debug.LogError("Что то не так");
        }
    }

    private void ConsequenceOfTheClick()
    {
        if (_clickCounter == _numberOfClicksForLaunchPhrase)
        {
            Debug.Log("Nice!");
        }

        if ((_playerStatistics._oreInBag += _oreMiningPerClick) <= _maximumAmountOreInBag)
        {
            _oreCounter.text = $"Руда: {_playerStatistics._oreInBag} / {_maximumAmountOreInBag}";
            ++_clickCounter;

        }
        else if ((_playerStatistics._oreInBag += _oreMiningPerClick) >= _maximumAmountOreInBag)
        {
            _playerStatistics._oreInBag += (_maximumAmountOreInBag - _playerStatistics._oreInBag);
            _oreCounter.text = $"Руда: {_playerStatistics._oreInBag} / {_maximumAmountOreInBag}";
            ++_clickCounter;
        }
    }
}
