using UnityEngine;

namespace MuratAltin.Runtime.Core
{
    /// <summary>
    /// Etkileþime geçilebilir tüm nesnelerin uygulamasý gereken temel arayüz.
    /// </summary>
    public interface IInteractable
    {
        #region Properties

        /// <summary>
        /// Etkileþim sýrasýnda ekranda görünecek isim/baþlýk.
        /// </summary>
        string InteractionTitle { get; }

        /// <summary>
        /// Etkileþim türüne göre deðiþen açýklama metni (Örn: "Aç", "Topla").
        /// </summary>
        string InteractionDescription { get; }

        /// <summary>
        /// Bu nesneyle þu an etkileþime geçilebilir mi?
        /// </summary>
        bool CanInteract { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Etkileþim tetiklendiðinde çalýþacak ana metod.
        /// </summary>
        void Interact();

       

        #endregion
    }
}