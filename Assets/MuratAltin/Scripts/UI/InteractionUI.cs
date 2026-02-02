using UnityEngine;
using TMPro; // TextMeshPro kullandýðýný varsayýyorum
using MuratAltin.Runtime.Core;

namespace MuratAltin.Runtime.UI
{
    /// <summary>
    /// Oyuncunun baktýðý nesneye göre ekrandaki etkileþim yazýsýný günceller.
    /// </summary>
    public class InteractionUI : MonoBehaviour
    {
        #region Fields

        [Header("UI References")]
        [SerializeField] private GameObject m_PromptPanel;
        [SerializeField] private TextMeshProUGUI m_PromptText;

        #endregion

        #region Methods

        /// <summary>
        /// Etkileþim panelini gösterir ve metni nesneye göre günceller.
        /// </summary>
        public void Show(IInteractable interactable)
        {
            if (interactable == null) return;

            m_PromptPanel.SetActive(true);
            // Artýk sýnýflardan gelen InteractionDescription tam cümleyi içerecek
            m_PromptText.text = interactable.InteractionDescription;
        }

        /// <summary>
        /// Etkileþim panelini gizler.
        /// </summary>
        public void Hide()
        {
            m_PromptPanel.SetActive(false);
        }

        #endregion
    }
}