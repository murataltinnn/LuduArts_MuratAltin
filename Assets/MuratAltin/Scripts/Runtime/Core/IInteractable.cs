using UnityEngine;

namespace MuratAltin.Runtime.Core
{
    public interface IInteractable
    {
        #region Properties
        string InteractionTitle { get; }
        string InteractionDescription { get; }
        bool CanInteract { get; }

        // 0 ise anlýk, >0 ise basýlý tutma süresidir.
        float InteractionDuration { get; }
        #endregion

        #region Methods
        void Interact();
        #endregion
    }
}