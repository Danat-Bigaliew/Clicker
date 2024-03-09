using UnityEngine;
using UnityEngine.Events;

namespace TS.PageSlider
{
    public class PageDot : MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent<bool> OnActiveStateChanged;
        public UnityEvent<int> OnPressed;

        public bool IsActive { get; private set; }
        public int Index { get; set; }

        private void Start()
        {
            ChangeActiveState(Index == 0);
        }

        public virtual void ChangeActiveState(bool active)
        {
            IsActive = active;

            OnActiveStateChanged?.Invoke(active);
        }
        public void Press()
        {
            OnPressed?.Invoke(Index);
        }
    }
}