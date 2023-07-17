using UnityEngine;


namespace Enemy
{ 
    public abstract class EnemyBaseState 
    {
        public readonly float AttackRange = 2f;
        public readonly float ChaseRange = 9f;
        public abstract void EnterState(EnemyStateManager stateManager, Transform target);
        public abstract void UpdateState(EnemyStateManager stateManager, Transform target, Transform targetRot);
    }

}

