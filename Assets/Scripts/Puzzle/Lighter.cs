using UnityEngine;

namespace Puzzle
{
    internal class Lighter : MonoBehaviour, IInteractable
    {
        [Tooltip("Set parent after picked up")]
        [SerializeField] private Transform parentTrans;
    
        [Tooltip("Set transform after picked up")]
        [SerializeField] private Transform targetTrans;

        [Tooltip("Light of the Lighter")]
        [SerializeField] private GameObject _spotLight;
        private bool _isLightTurnOn = false;                    //check if the light is on
        private bool _isPickedUp = false;                       //check if the lighter is picked up
    
        [Header("Light Raycast")]
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _rayPos;
        [SerializeField] private int _rayDistance;

        
        public static bool IsHitImg { get; private set; }       //check if the Lighter ray collides with Hidden_Image
        private void Awake()
        {
            _isLightTurnOn = false;
            IsHitImg = false;
        }

        //Interact to pickup the Lighter method
        #region IInteractable methods
        public void Interacted()
        {
            if(Input.GetKey(KeyCode.E) && _isPickedUp == false)
            {
                //Set Parent
                transform.parent = parentTrans;
                //Set Pos and Rot
                transform.position = targetTrans.position;
                transform.rotation = targetTrans.rotation;

                //Turn on the light
                _isLightTurnOn = true;
                _isPickedUp = true;
            }
       
        }
        public string GetDesctiption()
        {
            return "Pickup";
        }
        #endregion
        
        void Update()
        {
            //Trun on/off the light
            if(Input.GetKeyDown(KeyCode.E) && _isPickedUp == true)
            {
                _isLightTurnOn = !_isLightTurnOn;
            }
            _spotLight.SetActive(_isLightTurnOn);

            //If change items from weapon to lighter, Lighter will be invisible, then this won't work
            if (_isLightTurnOn == true && this.gameObject.activeInHierarchy == true)
            {
                LightRaycast();
            }
            
            //check if the light is off, then stop the image from hit
            if (_isLightTurnOn == false)
            {
                IsHitImg = false;
            }
        }

        private void LightRaycast()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hitInfo;


            if (Physics.Raycast(ray, out hitInfo, _rayDistance) == true)
            {
                //chack if Lighter reach the images
                IRevealable revealable = hitInfo.collider.gameObject.GetComponent<IRevealable>();
                if (revealable != null && _isLightTurnOn == true)
                {
                    IsHitImg = true;
                    revealable.Interacted();
                }
                else
                {
                    IsHitImg = false;
                }
            }
            else
            {
                IsHitImg = false;
            }
        }
    }
}


