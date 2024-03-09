using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainAnimations : MonoBehaviour
{
    [Header("Necessary Components")]
    [SerializeField] public Animator _animator;

    //[Header("Names Triggers And Parameters")]
    private string _toActionTrigger = "ToAction";
    private string _toIdleTrigger = "ToIdle";
    private string _speedActionParameter = "SpeedAction";
    private string _speedIdleParameter = "SpeedIdle";

    //[Header("Animation Names")]
    public string _nameAnimationIdle { get; set; } = "Idle";

    [Header("Updatable Parameters")]
    [SerializeField] private float ActionSpeed = 1f;
    [SerializeField] private float idleSpeed = 1f;

    public bool _isAnimationPlaying { get; set; } = false;

    private void Start()
    {

        if (_animator != null)
        {
            CheckAndSpeedParameter();
            Debug.Log("Покой");
            _animator.SetTrigger(_toIdleTrigger);
        }
        else
        {
            Debug.Log("Аниматор пуст");
        }
    }

    private void CheckAndSpeedParameter()
    {
        AnimatorControllerParameter[] parameters = _animator.parameters;
        bool speedWorkParameterExists = false;
        bool speedIdleParameterExists = false;

        foreach (var parameter in parameters)
        {
            if (parameter.name == _speedActionParameter && parameter.type == AnimatorControllerParameterType.Float)
            {
                speedWorkParameterExists = true;
                break;
            }

            if (parameter.name == _speedIdleParameter && parameter.type == AnimatorControllerParameterType.Float)
            {
                speedIdleParameterExists = true;
                break;
            }
        }

        if (!speedWorkParameterExists)
        {
            Debug.Log($"Параметр {_speedActionParameter} отсутствует в анимации. Добавляем его.");
            _animator.SetFloat(_speedActionParameter, ActionSpeed);
        }
        else
        {
            Debug.Log($"Параметр {_speedActionParameter} присутствует в анимации.");
        }

        if (!speedIdleParameterExists)
        {
            Debug.Log($"Параметр {_speedIdleParameter} отсутствует в анимации. Добавляем его.");
            _animator.SetFloat(_speedIdleParameter, idleSpeed);
        }
        else
        {
            Debug.Log($"Параметр {_speedIdleParameter} присутствует в анимации.");
        }
    }

    private void Update()
    {
        _animator.SetFloat(_speedIdleParameter, idleSpeed);
    }

    public IEnumerator PlayBlowAnimation(Button button)
    {
        _animator.SetTrigger(_toIdleTrigger);
        _animator.SetFloat(_speedActionParameter, ActionSpeed);
        _animator.SetTrigger(_toActionTrigger);

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

        button.interactable = true;

        yield return new WaitForSeconds(0f);

        _animator.SetTrigger(_toIdleTrigger);
        _isAnimationPlaying = false;

        yield return button;
    }
}
