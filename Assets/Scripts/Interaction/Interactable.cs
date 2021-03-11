using System;
using UnityEngine;

namespace DefaultNamespace.Interaction
{
    public abstract class Interactable : MonoBehaviour
    {
        private InteractionType _interactType;
        public InteractionType InteractType
        {
            get => _interactType;
            private set => _interactType = value;
        }
        
        public abstract void Interact();
        public enum InteractionType
        {
            Hold,
            DoubleTap
        }

    }
}