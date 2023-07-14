using UnityEngine;

namespace Enemy
{
    public class EnemyAttackState : EnemyBaseState
    {
        private Animator m_animator;
        private Vector3 m_lookPos;
        private Quaternion rotation;
        private float m_turnSpeed = 5f;
        public override void EnterState(EnemyStateManager stateManager, Transform target)
        {
            m_animator = stateManager.gameObject.GetComponent<Animator>();
           

        }

        public override void UpdateState(EnemyStateManager stateManager, Transform target, Transform targetRot)
        {
            m_lookPos = targetRot.position - stateManager.transform.position;
            m_lookPos.y = 0;
            rotation = Quaternion.LookRotation(m_lookPos);
            if (Vector3.Distance(stateManager.transform.position, target.position) <= AttackRange && Vector3.Distance(stateManager.transform.position, target.position) <= ChaseRange)
            {
                //stateManager.gameObject.transform.LookAt(target);
                stateManager.transform.rotation = Quaternion.Slerp(stateManager.transform.rotation, rotation, m_turnSpeed * Time.deltaTime);
                m_animator.SetBool("Attack", true);
            }
            else if (Vector3.Distance(stateManager.transform.position, target.position) >= AttackRange && Vector3.Distance(stateManager.transform.position, target.position) <= ChaseRange)
            {
                m_animator.SetBool("Attack", false);
                stateManager.SwitchState(stateManager.ChaseState);
            }
        }

    }
}