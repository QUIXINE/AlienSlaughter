using UnityEngine;

namespace Puzzle
{
    public class Statue01 : SubjectOfObserver, IInteractable
    {
        private Barrier _barrier;
        public bool Statue01IsRotated { get; private set; }
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
            if (transform.rotation == Quaternion.Euler(-90, 0, -90) || transform.rotation == Quaternion.Euler(-90, 0, 270))
            {
                Statue01IsRotated = true;
                NotifyObserver();
                //Destroy(this);
            }
            else
            {
                Statue01IsRotated = false;
                NotifyObserver();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.Rotate(0, 0, 90, Space.Self);
            }

            /*else if (Input.GetKeyDown(KeyCode.E) && Statue01IsRotated == false)
            {
                transform.Rotate(0, 90, 0);
            }*/



        }
        public string GetDesctiption()
        {
            return "Rotate";
        }


    }
}