using Enemy;
using Puzzle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TestStatic : MonoBehaviour
    {
        private Barrier[] _barrierArray = new Barrier[] {};
        private Barrier _barrier;
        private List<Barrier> _barrierList = new List<Barrier>();
        public GameObject TestStartValue;
        private static int m_testStartValueNum = 5;
        public  int TestStartValueNum;

        private void Awake()
        {
            m_testStartValueNum = 5;

        }
        void Start()
        {
            /*  //Test if static var really belongs to the class not instance
              Barrier._statueIsRotated01 = true;
              Barrier._statueIsRotated02 = true;
              Barrier._statueIsRotated03 = true;
              Barrier._statueIsRotated04 = true;
            */
            Barrier[] barrier = (Barrier[])FindObjectsOfType(typeof(Barrier));
            //_barrierList[0] = (Barrier)FindObjectOfType(typeof(Barrier));

            /*foreach (Barrier bar in barrier)
            {
                Debug.Log($"These are object with Barrier script + {bar.gameObject.name}");
            }
            for (int i = 0; i < barrier.Length; i++)
            {
                Debug.Log($"These are object with Barrier script {barrier[i].gameObject.name} at index number {i}");
            }*/
            print($"The value start again");
        }

        // Update is called once per frame
        void Update()
        {
            TestStartValueNum = m_testStartValueNum;
            
            if(Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(TestStartValue);
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                m_testStartValueNum = 0;
            }

        }
    }
}