using UnityEngine;
using MuratAltin.Runtime.Core;

namespace MuratAltin.Runtime.Interactables
{
    public class Door : MonoBehaviour, IInteractable
    {
        #region Fields
        private Animator m_Animator;
        [SerializeField] private bool m_IsOpen = false;

        
        private InteractionRequirement m_Requirement;
        #endregion

        #region Properties
      
        public string InteractionDescription => GetDescription();
        public bool CanInteract => true;
        public float InteractionDuration => 0f;
       
        #endregion

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
            m_Requirement = GetComponent<InteractionRequirement>();
            SyncAnimator();
        }

        public void Interact()
        {
            
            if (m_Requirement != null && !m_Requirement.IsMet())
            {
                Debug.Log(m_Requirement.GetWarningMessage());
                return;
            }

            m_IsOpen = !m_IsOpen;
            SyncAnimator();
        }

        private string GetDescription()
        {
            if (m_Requirement != null && !m_Requirement.IsMet())
                return "Locked - Key Required";

            return m_IsOpen ? "Press E to Close" : "Press E to Open"; 
        }

        private void SyncAnimator() => m_Animator.SetBool("m_IsOpen", m_IsOpen);
    }
}