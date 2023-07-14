using UnityEngine;
using System.Collections;

namespace Puzzle
{
    public class Barrier : Observer
    {
        public static bool _statueIsRotated01, _statueIsRotated02, _statueIsRotated03, _statueIsRotated04;
    
        //Show the variable below instead of static because static variable doesn't show in inspector
        [SerializeField] private bool _statueIsRotated01Showed, _statueIsRotated02Showed, _statueIsRotated03Showed, _statueIsRotated04Showed;
        private Vector3 _targetPos;

        private void Start()
        {
            _targetPos = new Vector3(transform.position.x, -2.3f, transform.position.z);   //Position that crystal will go to
            _statueIsRotated01 = false;
            _statueIsRotated02 = false;
            _statueIsRotated03 = false;
            _statueIsRotated04 = false;
        }

        private void Update()
        {
                /* Chaos of Static and non-static variable
            //why I have to assign every instance's bool (_statueIsRotated01Showed - 04) as true so that every barriers will move
            //if I only assign _statueIsRotated01Showed - 04 as true in one barrier, that one will move but the rest don't
            //I thought if I assign _statueIsRotated01Showed - 04 of one barrier as true, the four code blocks will assign 
            //_statueIsRotated01 - 04 (static bool) as true, and all barriers will move down because static var belongs to the class,
            //but they don't, Why?

                _statueIsRotated01 = _statueIsRotated01Showed;
                _statueIsRotated02 = _statueIsRotated02Showed;
                _statueIsRotated03 = _statueIsRotated03Showed;
                _statueIsRotated04 = _statueIsRotated04Showed;        

            ----------------Assumption 1----------------------
            //---> may be because after I rotate statue correctly, in every instance class will assign static bool as true like the case above
            //that I have to assign every the instances' bool variable so that every assigned barrier will move, but doesn't static belong to the class 
            //not the instance then why I have to assign every instances' variable?
            //After I tested to call public static var and assigned it, the result is it does belong to class not instance because all the barriers move
            //So why I have to assign all instance var (_statueIsRotated01Showed - 04) to make each of barriers move
            --------------------------------------------------
        
            ---------------- Additional ----------------------
            //I try this and all the barrier move down
                if(Input.GetMouseButtonDown(0))
                {
                    _statueIsRotated01 = true;
                    _statueIsRotated02 = true;
                    _statueIsRotated01 = true;
                    _statueIsRotated01 = true;
                }
            --------------------------------------------------
      
          */
            if (_statueIsRotated01 == true && _statueIsRotated02 == true && _statueIsRotated03 == true && _statueIsRotated04 == true)
            {
                //What's difference between 2 code blockse bewlow
                transform.position = Vector3.MoveTowards(transform.position, _targetPos, 0.5f * Time.deltaTime);
                //this.gameObject.transform.position += _targetPos * 0.5f * Time.deltaTime;
            }

            if(transform.position == _targetPos)
            {
                Destroy(this);
            }
        }
        public override void ReceiveSignal(SubjectOfObserver subject)
        {
            Statue01 statue01 = subject.GetComponent<Statue01>();
            Statue02 statue02 = subject.GetComponent<Statue02>();
            Statue03 statue03 = subject.GetComponent<Statue03>();
            Statue04 statue04 = subject.GetComponent<Statue04>();
        
            if (statue01 != null)
            {
                _statueIsRotated01 = statue01.Statue01IsRotated;
                _statueIsRotated01Showed = _statueIsRotated01;
            }
            if (statue02 != null)
            {
                _statueIsRotated02 = statue02.Statue02IsRotated;
                _statueIsRotated02Showed = _statueIsRotated02;
            } 
            if (statue03 != null)
            {
                _statueIsRotated03 = statue03.Statue03IsRotated;
                _statueIsRotated03Showed = _statueIsRotated03;

            }
            if (statue04 != null)
            {
                _statueIsRotated04 = statue04.Statue04IsRotated;
                _statueIsRotated04Showed = _statueIsRotated04;

            }

        }
    }
}
