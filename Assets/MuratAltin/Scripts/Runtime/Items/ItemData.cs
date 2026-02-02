using UnityEngine;

namespace MuratAltin.Runtime.Items
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "LuduArts/Item Data")]
    public class ItemData : ScriptableObject
    {
        #region Fields
        [SerializeField] private string m_ItemName;
        [SerializeField] private string m_ItemID; // Kapýdaki ID ile bu eþleþmeli
        #endregion

        #region Properties
        public string ItemName => m_ItemName;
        public string ItemID => m_ItemID;
        #endregion
    }
}