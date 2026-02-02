using UnityEngine;
using MuratAltin.Runtime.Core;
using MuratAltin.Runtime.Items;
using MuratAltin.Runtime.Player;

namespace MuratAltin.Runtime.Interactables
{
    public class KeyPickup : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemData m_Data;
        public string InteractionDescription => "Press [E] to collect the key";
        public bool CanInteract => true;
        public float InteractionDuration => 0f;
        public void Interact()
        {
            if (m_Data != null)
            {
                InventoryController.Instance.AddItem(m_Data.ItemID);
                gameObject.SetActive(false); // Objeyi sahneden kaldýr
            }
        }
    }
}