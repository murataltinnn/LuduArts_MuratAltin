using System.Collections.Generic;
using UnityEngine;
using MuratAltin.Runtime.Items;

namespace MuratAltin.Runtime.Player
{
    public class InventoryController : MonoBehaviour
    {
        public static InventoryController Instance; 

        [SerializeField] private List<string> m_CollectedItemIDs = new List<string>();

        private void Awake()
        {
            Instance = this;
        }

        public void AddItem(string itemID)
        {
            if (!m_CollectedItemIDs.Contains(itemID))
                m_CollectedItemIDs.Add(itemID);
        }

        public bool HasItem(string itemID)
        {
            return m_CollectedItemIDs.Contains(itemID);
        }
    }
}