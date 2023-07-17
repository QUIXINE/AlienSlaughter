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
        [Tooltip("Player position for enemy to chase after")]
        [SerializeField] private Transform targetPos;
        [Tooltip("Player rotation for enemy to chase after")]
        [SerializeField] private Transform targetRot;

        private void Start()
        {
            //Play VFX
            targetPos = GameObject.FindGameObjectWithTag("PlayerPosition").gameObject.transform;
            targetRot = GameObject.FindGameObjectWithTag("PlayerRotation").gameObject.transform;
            currentState = IdleState;
            currentState.EnterState(this, targetPos);
        }

        private void Update()
        {
            currentState.UpdateState(this, targetPos, targetRot);
        }

        public void SwitchState(EnemyBaseState state)
        {
            currentState = state;
            state.EnterState(this, targetPos);
        }
    }
}

