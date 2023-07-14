using UnityEngine;

namespace Enemy
{
    public class EnemyIdleState : EnemyBaseState
    {
        
        private Animator m_anim;
        public override void EnterState(EnemyStateManager stateManager, Transform target)
        {
            m_anim = stateManager.gameObject.GetComponent<Animator>();
            m_anim.Play("Idle");

        }
        public override void UpdateState(EnemyStateManager stateManager, Transform target, Transform targetRot)
        {
            if (Vector3.Distance(stateManager.transform.position, target.position) <= ChaseRange)
            {
                m_anim.SetBool("Idle", false);
                //m_anim.SetBool("Chase", true);
                //m_anim.SetBool("Attack", false);
                stateManager.SwitchState(stateManager.ChaseState);
            }
            else if(Vector3.Distance(stateManager.transform.position, target.position) <= AttackRange)
            {
                m_anim.SetBool("Idle", false);
                //m_anim.SetBool("Attack", true);
                //m_anim.SetBool("Chase", false);
                stateManager.SwitchState(stateManager.AttackState);
            }
        }

    }
}