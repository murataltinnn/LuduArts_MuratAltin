using UnityEngine;
using UnityEngine.Events;
using MuratAltin.Runtime.Core;

namespace MuratAltin.Runtime.Interactables
{
    public class Switch : MonoBehaviour, IInteractable
    {
        #region Fields
        [Header("Settings")]
        [SerializeField] private UnityEvent m_OnActivated;
        [SerializeField] private bool m_IsOneTimeUse = false;
        [Header("State")]
        [SerializeField] private bool m_IsOn = false; 
        #endregion
        #region Properties
        public float InteractionDuration => 0f;
        public string InteractionDescription => m_IsOn ? "Press [E] to turn off the light" : "Press [E] to turn on the light";
        public bool CanInteract => m_IsOneTimeUse ? !m_IsOn : true;
        #endregion
        public void Interact()
        {
            if (m_IsOneTimeUse && m_IsOn) return;
            m_IsOn = !m_IsOn;
            m_OnActivated?.Invoke();
        }
    }
}