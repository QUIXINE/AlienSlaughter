using UnityEngine;
namespace Puzzle
{
    public class Statue04 : SubjectOfObserver, IInteractable
    {
        private Barrier _barrier;
        public bool Statue04IsRotated { get; private set; }
        private void Awake()
        {
            _barrier = (Barrier)FindObjectOfType(typeof(Barrier));
        }
        private void OnEnable()
        {
            if (_barrier != null)
                Attach(_barrier);
        }

        private void OnDisable()
        {
            if (_barrier != null)
                Detach(_barrier);
        }
    
        public void Interacted()
        {
        

            if (Input.GetKeyDown(KeyCode.E) )
            {
                transform.Rotate(0, 0, 90, Space.Self);
            }/*if (Input.GetKeyDown(KeyCode.E) && Statue04IsRotated == false)
            {
                transform.Rotate(0, 45, 0);
            }*/
            if (transform.rotation == Quaternion.Euler(-90, 0 ,90) || transform.rotation == Quaternion.Euler(-90, 0 ,- 270))
            {
                Statue04IsRotated = true;
                NotifyObserver();
                //Destroy(this);
            }
            else
            {
                Statue04IsRotated = false;
                NotifyObserver();
            }

        }
        public string GetDesctiption()
        {
            return "Rotate";
        }


    }
}
