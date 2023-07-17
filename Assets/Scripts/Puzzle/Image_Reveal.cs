using UnityEngine;

namespace Puzzle
{
    public class Image_Reveal : MonoBehaviour, IRevealable
    {
        private bool isRevealable;                      //used to check if the light's ray hits the Hidden_Image or not
        private SpriteRenderer spriteRenderer;          //used to enable/unenable

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public void Interacted()
        {
            isRevealable = true;
        }

        private void Update()
        {
            if(Lighter.IsHitImg == false)
            {
                isRevealable = false;
            }
            //meaning? --> isRevalable |= isRevalable && !isRevalable;
            
            spriteRenderer.enabled = isRevealable;
        }
    }
}