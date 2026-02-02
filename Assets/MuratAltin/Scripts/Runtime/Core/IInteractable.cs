using UnityEngine;

namespace MuratAltin.Runtime.Core
{
    public interface IInteractable
    {
        #region Properties
        string InteractionDescription { get; }
        bool CanInteract { get; }

        
        float InteractionDuration { get; }
        #endregion

        #region Methods
        void Interact();
        #endregion
    }
}