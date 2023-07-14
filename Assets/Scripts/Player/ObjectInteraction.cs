using UnityEngine;

namespace Assets.Scripts
{
    internal class ObjectInteraction : MonoBehaviour
    {
        [Tooltip("Camera used for ray interaction with object")]
        [SerializeField] private Camera _camera;

        [Tooltip("Ray distance of camera to check the object to interact with")]
        [SerializeField] private float _rayDis;

        private void Update()
        {
            Interaction();
        }
        private void Interaction()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, _rayDis))
            {
                IInteractable interactable = hitInfo.collider.gameObject.GetComponent<IInteractable>();
                if(interactable != null)
                {
                    Debug.Log(hitInfo.collider.gameObject.name);
                    Debug.Log(interactable.GetDesctiption());
                    interactable.Interacted();
                }
            }

        }
    }
}
