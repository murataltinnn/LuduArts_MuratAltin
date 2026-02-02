using MuratAltin.Runtime.Core;
using MuratAltin.Runtime.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MuratAltin.Runtime.Player
{
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields
        [Header("Settings")]
        [SerializeField] private float m_InteractionRange = 5f;
        [SerializeField] private LayerMask m_InteractableLayer;
        [SerializeField] private Transform m_CameraTransform;
        [SerializeField] private InteractionUI m_InteractionUI;

        [Header("Hold Settings")]
        [SerializeField] private Slider m_ProgressSlider;

        private IInteractable m_CurrentInteractable;
        private float m_HoldTimer = 0f;
        #endregion

        private void Start()
        {
            if (m_ProgressSlider != null) m_ProgressSlider.gameObject.SetActive(false);
        }

        private void Update()
        {
            DetectInteractable();
            HandleInteractionInput();
        }

        private void HandleInteractionInput()
        {
            if (m_CurrentInteractable == null || !m_CurrentInteractable.CanInteract)
            {
                ResetHold();
                return;
            }

            // DURUM 1: Anlýk Etkileþim (Kapý, Iþýk vb.)
            if (m_CurrentInteractable.InteractionDuration <= 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    m_CurrentInteractable.Interact();
                    m_InteractionUI.Show(m_CurrentInteractable);
                }
                return;
            }

            // DURUM 2: Basýlý Tutma (Sandýk vb.)
            if (Input.GetKey(KeyCode.E))
            {
                m_HoldTimer += Time.deltaTime;

                if (m_ProgressSlider != null)
                {
                    m_ProgressSlider.gameObject.SetActive(true);
                    // Slider'ýn max deðerini 4 yaptýðýn için timer'ý direkt veriyoruz
                    m_ProgressSlider.value = m_HoldTimer;
                }

                if (m_HoldTimer >= m_CurrentInteractable.InteractionDuration)
                {
                    m_CurrentInteractable.Interact();
                    m_InteractionUI.Show(m_CurrentInteractable);
                    ResetHold();
                }
            }
            else
            {
                ResetHold();
            }
        }

        private void ResetHold()
        {
            m_HoldTimer = 0f;
            if (m_ProgressSlider != null)
            {
                m_ProgressSlider.value = 0;
                m_ProgressSlider.gameObject.SetActive(false);
            }
        }

        private void DetectInteractable()
        {
            Ray ray = new Ray(m_CameraTransform.position, m_CameraTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, m_InteractionRange, m_InteractableLayer))
            {
                if (hit.collider.transform.root.TryGetComponent(out IInteractable interactable))
                {
                    if (m_CurrentInteractable != interactable)
                    {
                        m_CurrentInteractable = interactable;
                        m_InteractionUI.Show(m_CurrentInteractable);
                    }
                    return;
                }
            }

            m_CurrentInteractable = null;
            m_InteractionUI.Hide();
            ResetHold();
        }
    }
}