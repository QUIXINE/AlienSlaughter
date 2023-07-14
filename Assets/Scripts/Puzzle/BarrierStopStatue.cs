using System.Collections;
using UnityEngine;

namespace Puzzle
{
    public class BarrierStopStatue : SubjectOfObserver
    {

        private StatueStopByBarrier _statueObserver;
        private Vector3 _defaultTransform;
        public bool IsStatuesEnable { get; private set; } = true;

        private void Awake()
        {
            _statueObserver = (StatueStopByBarrier)FindObjectOfType(typeof(StatueStopByBarrier));
            _defaultTransform = this.gameObject.transform.position;
        }
        private void OnEnable()
        {
            if (_statueObserver != null)
                Attach(_statueObserver);
        }

        private void OnDisable()
        {
            if (_statueObserver != null)
                Detach(_statueObserver);
        }

        private void Update()
        {
            if(transform.position != _defaultTransform)
            {
                IsStatuesEnable = false;
                NotifyObserver();
            }
        }
    }
}