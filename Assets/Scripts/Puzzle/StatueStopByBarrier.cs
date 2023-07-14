using System.Collections;
using UnityEngine;

namespace Puzzle
{
    public class StatueStopByBarrier : Observer
    {
        private static bool _isEnable = true;
        private Statue01 _statue01;
        private Statue02 _statue02;
        private Statue03 _statue03;
        private Statue04 _statue04;
        private void Awake()
        {
            _statue01 = FindAnyObjectByType<Statue01>();
            _statue02 = FindAnyObjectByType<Statue02>();
            _statue03 = FindAnyObjectByType<Statue03>();
            _statue04 = FindAnyObjectByType<Statue04>();
            _isEnable = true;
        }

        private void Update()
        {
            if(_isEnable == false)
            {
                Destroy(_statue01);
                Destroy(_statue02);
                Destroy(_statue03);
                Destroy(_statue04);
                /*Why can't use these
                    _statue01.enabled = false;
                    _statue02.enabled = false;
                    _statue03.enabled = false;
                    _statue04.enabled = false;
                */
                Destroy(this);
            }
        }
        public override void ReceiveSignal(SubjectOfObserver subject)
        {
            BarrierStopStatue barrierSubjectOfObserver = subject.GetComponent<BarrierStopStatue>();
            if(barrierSubjectOfObserver != null)
            {
                _isEnable = barrierSubjectOfObserver.IsStatuesEnable;
            }
        }

       
    }
}