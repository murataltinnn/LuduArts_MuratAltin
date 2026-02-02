using UnityEngine;

namespace MuratAltin.Runtime.Tools
{
    public class ToggleTool : MonoBehaviour
    {
        [SerializeField] private GameObject m_TargetObject;

        /// <summary>
        /// Hedef objenin aktiflik durumunu tersine çevirir.
        /// </summary>
        public void ToggleActive()
        {
            if (m_TargetObject != null)
            {
                bool currentState = m_TargetObject.activeSelf;
                m_TargetObject.SetActive(!currentState);
            }
        }
    }
}
