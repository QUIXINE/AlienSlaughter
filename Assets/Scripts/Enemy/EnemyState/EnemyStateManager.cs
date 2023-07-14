using UnityEngine;

namespace Enemy
{
    public class EnemyStateManager : MonoBehaviour
    {
        private EnemyBaseState currentState;
        
        public EnemyIdleState IdleState = new EnemyIdleState();
        public EnemyAttackState AttackState = new EnemyAttackState();
        public EnemyChaseState ChaseState = new EnemyChaseState();

        //Player tarnsform to use with NavMeshAgent
        [SerializeField] private Transform m_targetPos;
        [SerializeField] private Transform m_targetRot;

        private void Start()
        {
            //Play VFX
            m_targetPos = GameObject.FindGameObjectWithTag("PlayerPosition").gameObject.transform;
            m_targetRot = GameObject.FindGameObjectWithTag("PlayerRotation").gameObject.transform;
            print(m_targetPos);
            currentState = IdleState;
            currentState.EnterState(this, m_targetPos);
        }

        private void Update()
        {
            currentState.UpdateState(this, m_targetPos, m_targetRot);
        }

        public void SwitchState(EnemyBaseState state)
        {
            currentState = state;
            state.EnterState(this, m_targetPos);
        }
    }
}

