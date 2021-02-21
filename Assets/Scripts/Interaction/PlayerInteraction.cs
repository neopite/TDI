using System;
using UnityEngine;

namespace DefaultNamespace.Interaction
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField]private float _doubleTapTime;
        private float _prevTapTime;
        public void Start()
        {
            
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 currMousePosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D raycastHit2D = Physics2D.Raycast(currMousePosition,Vector2.zero);
                Interactable interactable;
                Debug.Log(raycastHit2D.collider);
                if(raycastHit2D.collider.TryGetComponent<Interactable>(out interactable))
                {
                    HandleInteraction(interactable);
                }
            }
        }

        private void HandleInteraction(Interactable interactable)
        {
            Interactable.InteractionType interactionType = interactable.interactType;
            switch (interactionType)
            {
                case Interactable.InteractionType.DoubleTap :
                    if (Time.time - _prevTapTime < _doubleTapTime)
                    {
                        interactable.Interact();
                    }
                    _prevTapTime = Time.deltaTime;
                    break;
                default: throw new Exception("Not such Interaction Type as mentioned");
            }
        }
    }
}