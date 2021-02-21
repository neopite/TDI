using System;
using UnityEngine;

namespace DefaultNamespace.Interaction
{
    public abstract class Interactable : MonoBehaviour
    {
        public InteractionType interactType;
        public InteractionType InteractType
        {
            get => interactType;
            private set => interactType = value;
        }
        
        public abstract void Interact();
        public enum InteractionType
        {
            Hold,
            DoubleTap
        }

    }
}