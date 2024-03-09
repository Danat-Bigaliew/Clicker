using UnityEngine;
using UnityEngine.Events;

namespace TS.PageSlider
{
    public class PageView : MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent OnChangingToActiveState;
        public UnityEvent OnChangingToInactiveState;
        public UnityEvent<bool> OnActiveStateChanged;

        public void ChangingToActiveState()
        {
            OnChangingToActiveState?.Invoke();
        }

        public void ChangingToInactiveState()
        {
            OnChangingToInactiveState?.Invoke();
        }

        public void ChangeActiveState(bool active)
        {
            OnActiveStateChanged?.Invoke(active);
        }
    }
}