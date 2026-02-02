using UnityEngine;
using UnityEngine.Events;
using MuratAltin.Runtime.Core;

namespace MuratAltin.Runtime.Interactables
{
    public class Switch : MonoBehaviour, IInteractable
    {
        #region Fields
        [Header("Settings")]
        [SerializeField] private string m_Title = "Þalter";
        [SerializeField] private UnityEvent m_OnActivated;
        [SerializeField] private bool m_IsOneTimeUse = false;

        [Header("State")]
        [SerializeField] private bool m_IsOn = false; // Þalterin þu anki durumu
        #endregion

        #region Properties
        public string InteractionTitle => m_Title;

        // Duruma göre yazýyý deðiþtiriyoruz
        public string InteractionDescription => m_IsOn ? "Kapat" : "Çalýþtýr";

        public bool CanInteract => m_IsOneTimeUse ? !m_IsOn : true;
        #endregion
       

        public void Interact()
        {
            // Eðer tek kullanýmlýksa ve zaten açýlmýþsa iþlem yapma
            if (m_IsOneTimeUse && m_IsOn) return;

            // Durumu tersine çevir (Toggle)
            m_IsOn = !m_IsOn;

            // Baðlý olan her þeyi (Iþýðý, kapýyý vb.) tetikle
            m_OnActivated?.Invoke();

            Debug.Log(m_IsOn ? "Þalter Açýldý" : "Þalter Kapatýldý");
        }
    }

}