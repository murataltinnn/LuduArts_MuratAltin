using UnityEngine;
using MuratAltin.Runtime.Player;

namespace MuratAltin.Runtime.Core
{
    public class KeyRequirement : InteractionRequirement
    {
        [SerializeField] private string m_RequiredKeyID;

        public override bool IsMet()
        {
            // Envanter kontrolü
            if (InventoryController.Instance == null) return false;
            return InventoryController.Instance.HasItem(m_RequiredKeyID);
        }

        public override string GetWarningMessage()
        {
            return "";
        }
    }
}