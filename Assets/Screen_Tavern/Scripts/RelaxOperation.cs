using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelaxOperation : MonoBehaviour
{
    [SerializeField] private float _oreMiningPerClick = 100;
    private float _oreInBag = 0;
    public Button _button { get; private set; }
    private MainAnimations _mainAnimation;

    private void Start()
    {
        _button = GetComponent<Button>();
        _mainAnimation = GetComponent<MainAnimations>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Кнопка не найдена.");
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
        Debug.Log("Активация алкаша");
        _oreInBag = _oreMiningPerClick;
        Debug.Log($"Вы добыли {_oreMiningPerClick} руды");
        Debug.Log($"В сумке {_oreInBag} руды");
    }
}
