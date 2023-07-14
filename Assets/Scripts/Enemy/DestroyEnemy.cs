using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

namespace Enemy
{
    public class DestroyEnemy : Observer
    {
        private Animator m_animator;
        private EnemyStateManager m_state;
        private NavMeshAgent m_meshAgent;
        private void Start()
        {
            m_animator = GetComponent<Animator>();
            m_state = GetComponent<EnemyStateManager>();
            m_meshAgent = GetComponent<NavMeshAgent>();
        }
        public override void ReceiveSignal(SubjectOfObserver subject)
        { 
            m_animator.SetBool("Die", true);
            //stop State script
            m_state.enabled = false;
            
            //stop NavMesh agent because even State script is stoped, enemy still chasing if it met the condition
            //then I tried stoping NavMesh agent and it works. Have no idea why?!!
            m_meshAgent.enabled = false;
            
            //Destroy time is related with its animation and Life Sentry Die animation
            Destroy(this.gameObject, 5f);
        }  
    }
}

/*Another way to do
    used if I use option 3 in Another way to do section in LifeSentryHealth
    
    m_enemyHealth = FindObjectsOfType<EnemyHealth>().ToList();
    foreach(EnemyHealth enemyHealth in m_enemyHealth)
    {
        Destroy(enemyHealth.gameObject, 3f);
    }
*/