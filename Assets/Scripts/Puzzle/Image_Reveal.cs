using UnityEngine;

namespace Puzzle
{
    public class Image_Reveal : MonoBehaviour, IRevealable
    {
        private bool isRevalable;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public void Interacted()
        {
            isRevalable = true;
        }

        private void Update()
        {
            if(Lighter.IsHitImg == false)
            {
                isRevalable = false;
            }
            // meaning? --> isRevalable |= isRevalable && !isRevalable;
            
            spriteRenderer.enabled = isRevalable;
        }
    }
}