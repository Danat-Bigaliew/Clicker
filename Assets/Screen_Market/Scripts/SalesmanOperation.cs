using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SalesmanOperation : MonoBehaviour
{
    [SerializeField] private float _sellingOrePerClick = 100;
    [SerializeField] public float _sellOrePerClick = 15;
    public Button _button { get; private set; }
    private MainAnimations _mainAnimation;
    private PlayerStatistics _playerStatistics;

    [SerializeField] private TextMeshProUGUI _oreCounterForSale;

    private void Start()
    {
        _button = GetComponent<Button>();
        _mainAnimation = GetComponent<MainAnimations>();
        _playerStatistics = GetComponent<PlayerStatistics>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Кнопка не найдена.");
        }

        if (_playerStatistics == null)
        {
            Debug.LogError("PlayerStatistics не найден.");
        }
    }

    private void Update()
    {
        _oreCounterForSale.text = $"Руда: {_playerStatistics._oreInBag}";
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
        if(_playerStatistics._oreInBag >= _sellOrePerClick)
        {
            Debug.Log("Получилось");
        }
    }
}
