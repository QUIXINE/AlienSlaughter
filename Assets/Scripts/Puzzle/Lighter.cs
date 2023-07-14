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
        private bool _isLightTurnOn = false;                //check if the light is on
        private bool _isPickedUp = false;                   //check if the lighter is picked up
    
        [Header("Light Raycast")]
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _rayPos;
        [SerializeField] private int _rayDistance;

        [Tooltip("Image to be exposed by the lighter")]
        [Header("Hidden Image")]
        [SerializeField] private GameObject _hiddenImg;
        [SerializeField] private Collider _hiddenImgCollider;
        private bool _isHitImg;

        private void Awake()
        {
            _isLightTurnOn = false;
        }
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
            return null;
        }
    
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
        
            if (_isLightTurnOn == false)
            {
                _isHitImg = false;
            }
            _hiddenImg.SetActive(_isHitImg);
        }

        private void LightRaycast()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, _rayDistance))
            {
                if (hitInfo.collider == _hiddenImgCollider && _isLightTurnOn == true)
                {
                    Debug.Log("Ligh Ray Detech " + hitInfo.collider.name);
                    _isHitImg = true;
                }
                else if(hitInfo.collider == null)
                {
                    _isHitImg = false;
                }
                else
                {
                    _isHitImg = false;
                }
                Debug.Log("Hit sth " + hitInfo.collider.name);

            }
        }
    }
}


