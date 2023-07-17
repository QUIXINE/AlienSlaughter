using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy
{
    public class LifeSentryHealth : SubjectOfObserver, IDamagable
    {
        [SerializeField] private int m_health;
       
        private List<DestroyEnemy> m_destroyEnemyList = new List<DestroyEnemy>();   //List to add ObjectsOfType to
        private bool m_isArrayFull = true;                                          //used to check if there's any objs inside List

        private void Awake()
        {
            m_destroyEnemyList = FindObjectsOfType<DestroyEnemy>().ToList();
            m_isArrayFull = true;
        }
        
        private void OnEnable()
        {
            //the first values are in here
            foreach (DestroyEnemy destroyEnemy in m_destroyEnemyList)
            {
                Attach(destroyEnemy);
            }
        }

        private void OnDisable()
        {
            //the first ones are in here
            foreach (DestroyEnemy destroyEnemy in m_destroyEnemyList)
            {
                Detach(destroyEnemy);
            }
        }

        private void Update()
        {
            //What can I do not to use this method inside Update
            ChangeValuesInList();
        }

        private void ChangeValuesInList()
        {
            if (EnemyHealth.EnemyCount <= 0 && m_isArrayFull == true)
            {
                //Remove all old objs of array and add new
                foreach (DestroyEnemy destroyEnemy in m_destroyEnemyList)
                {
                    Detach(destroyEnemy);
                }
                m_destroyEnemyList.Clear();
                m_isArrayFull = false;
            }

            if (EnemyHealth.EnemyCount == 13 && m_isArrayFull == false)
            {
                m_destroyEnemyList = FindObjectsOfType<DestroyEnemy>().ToList();
                foreach (DestroyEnemy destroyEnemy in m_destroyEnemyList)
                {
                    Attach(destroyEnemy);
                }
                m_isArrayFull = true;
            }
        }

        public void TakeDamage(int damage)
        {
            m_health -= damage;
            if (m_health <= 0)
            {
                //****play animation
                //Destroy time is related with its animation and Enemy Die animation
                Destroy(this.gameObject, 3f); //Life sentry die before enemies because it will look smoothier

                //----------------------------
                //this code try to reach DestroyEnemy after it's destroyed, so it errors
                NotifyObserver();   
                //----------------------------
            }
        }
    }
}


/*Array to contain DestroyEnemy script
    m_destroyEnemyArray = (DestroyEnemy[])FindObjectsOfType(typeof(DestroyEnemy
    for (int i = 0; i < m_destroyEnemyArray.Length; i++)
    {
        Debug.Log($"These are enemies with DestroyEnemy script {m_destroyEnemyArray[i].gameObject.name}");
    }
*/

/*List to contain DestroyEnemy script
    private List<DestroyEnemy> m_destroyEnemyList;
                 
    private void ...Method...()
    {    m_destroyEnemyList = FindObjectsOfType<DestroyEnemy>().ToList();
                    
        //for-loop to check what's inside m_destroyEnemyList
        for (int i = 0; i < m_destroyEnemyList.Count; i++)
        {
            Debug.Log($"These are enemies with DestroyEnemy script {m_destroyEnemyArray[i].gameObject.name}");
        }
    }
*/

/*Input check if the code works --> test if after killed enemy will new enemy Add to the list
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    m_health -= 5;
                }
                if (m_health <= 0)
                {
                    //play animation
                    //Destroy time is related with its animation and Enemy Die animation
                    Destroy(this.gameObject, 3f);
                    //this code try to reach DestroyEnemy after it's destroyed, so it errors
                    NotifyObserver();
                }
            */

/*  Problem: Null reference of _observerList (in SubjectOfObserver)
    After destroy enemy with DestroyEnemy script as a component in each Enemy objects
    the error said that the object of type DestroyEnemy has been destroyed, so I try to use 
    Attach and Detatch to Add and Remove List of the old ones and it works.

    ---------------------------------- Result --------------------------------------
    because OnEnable works after the script is enable, if there's no any changes of
    values, they will still be the same values after OnEnable called (the values in m_destroyEnemyArrayList)
    are Attach() or Add() to the _observerList, so if don't Remove() and Add() new values to the _observerList 
    after those values(DestroyEnemy script) are destroyed, they'll be an error because _observerList still 
    references the same values that are destroyed.
    So I coded to check the condition and change the values inside _observerList
    so that there will be change of the values in side _observerList (in SubjectOfObserver)
    by clearing _observerList, m_destroyEnemyList and m_destroyEnemyArrayList after EnemyHealth.EnemyCount = 0,
    and adding new values to those three variables after EnemyHealth.EnemyCount = 5

    *** There's another way to do it --> look in the "Another way to do" section ***
    --------------------------------------------------------------------------------

    //Check what inside the m_destroyEnemyArrayList are
    for (int i = 0; i < m_destroyEnemyArrayList.Count && EnemyHealth.EnemyCount == 5; i++)
    {
        Debug.Log($"These are enemies with DestroyEnemy script {m_destroyEnemyArrayList[i]} at the index {i}");
    }

    if (EnemyHealth.EnemyCount <= 0 && m_isArrayFull == true)
    {
        //Remove all old objs of array and add new
        foreach (DestroyEnemy destroyEnemy in m_destroyEnemyArrayList)
        {
            Detach(destroyEnemy);
        }
        m_destroyEnemyList.Clear();
        m_destroyEnemyArrayList.Clear();
        m_isArrayFull = false;
    }

    if (EnemyHealth.EnemyCount == 5 && m_isArrayFull == false)
    {
        m_destroyEnemyList = FindObjectsOfType<DestroyEnemy>().ToList();
        m_destroyEnemyArrayList.AddRange(m_destroyEnemyList);
        foreach (DestroyEnemy destroyEnemy in m_destroyEnemyArrayList)
        {
            Attach(destroyEnemy);
        }
        m_isArrayFull = true;
    }
*/

/*Another way to do
    ------------------------------ Option 1 ---------------------------------------
    use ArrayList along with List
    private ArrayList m_destroyEnemyArrayList = new ArrayList();                
    add m_destroyEnemyArrayList.AddRange(m_destroyEnemyList); in Awake()
    and change every foreach List to m_destroyEnemyArrayList
    add m_destroyEnemyArrayList.Clear(); in EnemyHealth.EnemyCount <= 0 if-condition
    add m_destroyEnemyArrayList.AddRange(m_destroyEnemyList); in EnemyHealth.EnemyCount == 5 if-condition
    ------------------------------ Option 1 ---------------------------------------
  
    ------------------------------ Option 2 ---------------------------------------
    Create empty gameObject in Unity, add DestroyEnemy as component
    use m_destroyEnemyList = FindObjectsOfType<DestroyEnemy>().ToList(); or 
    m_destroyEnemy = (DestroyEnemy)FindObjectOfType(typeof(DestroyEnemy)); 
    
    (this solves the problem that if I add the code to Enemy, after the enemies are destroyed
    the Object in List will be null if I don't attach a new one - what it does is just references 
    to the only Object that will not be destroyed(only destroyed as observer not by taking damage 
    and instantiated as new obj)
    And and there's some code needed inside DestroyEnemy(the code is in Another way to do)
    ------------------------------ Option 2 ---------------------------------------

    ------------------------------ Option 3 ---------------------------------------
    make object pool with Enemy so that objects in _observerList (in SubjectOfObserver) are always the same one
    and don't have to Add() and Remove() unnecessarily
    *** This option is just my assumption because right now (7/18/2023) 
        I'm not really sure how Object Pooling work             ***
    ------------------------------ Option 3 ---------------------------------------

 */