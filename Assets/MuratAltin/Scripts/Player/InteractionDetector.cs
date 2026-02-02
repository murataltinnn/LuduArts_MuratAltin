using MuratAltin.Runtime.Core;
using MuratAltin.Runtime.UI;
using UnityEngine;
// Slider kütüphanesini sildik çünkü artýk süre bazlý etkileþim yok

namespace MuratAltin.Runtime.Player
{
    /// <summary>
    /// Oyuncunun baktýðý nesneleri tespit eder ve etkileþimi yönetir.
    /// Sadece anlýk (E'ye bas-çalýþtýr) etkileþimleri destekler.
    /// </summary>
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields

        [Header("Settings")]
        [SerializeField] private float m_InteractionRange = 5f;
        [SerializeField] private LayerMask m_InteractableLayer;
        [SerializeField] private Transform m_CameraTransform;

        [Header("References")]
        [SerializeField] private InteractionUI m_InteractionUI;

        private IInteractable m_CurrentInteractable;

        #endregion

        #region Unity Methods

        private void Update()
        {
            DetectInteractable();

            // Etkileþim kontrolü: Sadece GetKeyDown (Anlýk basýþ) kullanýyoruz
            if (Input.GetKeyDown(KeyCode.E) && m_CurrentInteractable != null)
            {
                if (m_CurrentInteractable.CanInteract)
                {
                    m_CurrentInteractable.Interact();

                    // Etkileþim sonrasý metni güncelle (Örn: "Aç" -> "Kapat")
                    m_InteractionUI.Show(m_CurrentInteractable);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raycast ile bakýlan objeyi bulur ve UI'ý tetikler.
        /// </summary>
        private void DetectInteractable()
        {
            Ray ray = new Ray(m_CameraTransform.position, m_CameraTransform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, m_InteractionRange, m_InteractableLayer))
            {
                // Root veya child objede IInteractable ara
                if (hit.collider.transform.root.TryGetComponent(out IInteractable interactable))
                {
                    m_CurrentInteractable = interactable;
                    m_InteractionUI.Show(m_CurrentInteractable);
                    return;
                }
            }

            // Menzilden çýkýnca her þeyi sýfýrla
            m_CurrentInteractable = null;
            m_InteractionUI.Hide();
        }

        #endregion
    }
}