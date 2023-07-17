using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyChaseState : EnemyBaseState
    {
        private Animator m_animator;
        private NavMeshAgent m_navMeshAgent;

        private Vector3 m_lookPos;
        private Quaternion rotation;
        private float m_turnSpeed = 5f;
        public override void EnterState(EnemyStateManager stateManager, Transform target)
        {
            m_animator = stateManager.gameObject.GetComponent<Animator>();
            m_navMeshAgent = stateManager.gameObject.GetComponent<NavMeshAgent>();
           
        }

        public override void UpdateState(EnemyStateManager stateManager, Transform target, Transform targetRot)
        {
            m_lookPos = targetRot.position - stateManager.transform.position;
            m_lookPos.y = 0;
            rotation = Quaternion.LookRotation(m_lookPos);
            stateManager.transform.rotation = Quaternion.Slerp(stateManager.transform.rotation, rotation, m_turnSpeed * Time.deltaTime);

            m_animator.SetBool("Chase", true);
            m_navMeshAgent.SetDestination(target.position);

            if (Vector3.Distance(stateManager.transform.position, target.position) <= AttackRange)
            {
                m_animator.SetBool("Chase", false);
                stateManager.SwitchState(stateManager.AttackState);
            }
           
            
        }

        

    }
}
/*This will make enemy only chase on the condition
 else if (Vector3.Distance(stateManager.transform.position, target.position) >= AttackRange && Vector3.Distance(stateManager.transform.position, target.position) <= ChaseRange)
           {
               m_animator.SetBool("Chase", true);
               //stateManager.gameObject.transform.LookAt(target);
               m_navMeshAgent.SetDestination(target.position);
           }*/