using UnityEngine;
using MuratAltin.Runtime.Core;
using MuratAltin.Runtime.Items;
using MuratAltin.Runtime.Player;

namespace MuratAltin.Runtime.Interactables
{
    public class KeyPickup : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemData m_Data;

        // Ekranda "Kýrmýzý Anahtar" gibi bir baþlýk yazar
        public string InteractionTitle => m_Data != null ? m_Data.ItemName : "Eþya";

        // Ekranda "[E] Topla" yazar
        public string InteractionDescription => "Topla";

        public bool CanInteract => true;
       

        public void Interact()
        {
            if (m_Data != null)
            {
                InventoryController.Instance.AddItem(m_Data.ItemID);
                Debug.Log(m_Data.ItemName + " toplandý!");
                gameObject.SetActive(false); // Objeyi sahneden kaldýr
            }
        }
    }
}