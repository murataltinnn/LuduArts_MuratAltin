using UnityEngine;
using MuratAltin.Runtime.Core;

namespace MuratAltin.Runtime.Interactables
{
    public class Chest : MonoBehaviour, IInteractable
    {
        #region Fields
        [Header("Settings")]
        [SerializeField] private float m_OpenDuration = 3.0f;
        [SerializeField] private GameObject m_ItemInside; // Sandýðýn içindeki eþya (Görseli)

        private Animator m_Animator;
        private bool m_IsOpened = false;
        private bool m_ItemTaken = false;
        #endregion

        #region Properties
        public string InteractionTitle => "Eski Sandýk";

        public string InteractionDescription
        {
            get
            {
                if (!m_IsOpened) return "Açmak için Basýlý Tut";
                if (!m_ItemTaken) return "Eþyayý Almak için ";
                return "Boþ";
            }
        }

        public bool CanInteract => !m_ItemTaken; // Eþya alýnana kadar etkileþim sürsün

        // Sandýk açýlana kadar 4 saniye, açýldýktan sonra eþyayý almak için 0 saniye (anlýk)
        public float InteractionDuration => m_IsOpened ? 0f : m_OpenDuration;
        #endregion

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
            if (m_ItemInside != null) m_ItemInside.SetActive(false); // Baþta kapalý olsun
        }

        public void Interact()
        {
            // Durum 1: Sandýk henüz açýlmamýþsa
            if (!m_IsOpened)
            {
                m_IsOpened = true;
                if (m_Animator != null) m_Animator.SetBool("m_IsOpen_Chest", true);

                if (m_ItemInside != null) m_ItemInside.SetActive(true); // Eþyayý göster
                Debug.Log("Sandýk açýldý, eþya göründü!");
            }
            // Durum 2: Sandýk açýk ama eþya henüz alýnmamýþsa
            else if (!m_ItemTaken)
            {
                m_ItemTaken = true;
                if (m_ItemInside != null) m_ItemInside.SetActive(false); // Eþyayý "al" (gizle)

                // Buraya envanter ekleme kodunu yazabilirsin:
                // InventoryController.Instance.AddItem("SandikItemi");

                Debug.Log("Eþya sandýktan alýndý!");
            }
        }
    }
}