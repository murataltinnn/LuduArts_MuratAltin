using UnityEngine;

namespace MuratAltin.Runtime.Core
{
    public abstract class InteractionRequirement : MonoBehaviour
    {
        public abstract bool IsMet();
        public abstract string GetWarningMessage();
    }
}