using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : SubjectOfObserver, IDamagable
    {
        public static int EnemyCount = 5;
        private InstantiateEnemy m_instantiateEnemy;

        //health variables
        [SerializeField] private int m_health;
        private bool m_canBeAttacked;

        private void Awake()
        {
            m_instantiateEnemy = (InstantiateEnemy)FindObjectOfType(typeof(InstantiateEnemy));
            m_canBeAttacked = true;
        }
        private void Start()
        {
            EnemyCount = 5;

        }
        private void OnEnable()
        {
            if (m_instantiateEnemy != null)
                Attach(m_instantiateEnemy);
        }

        private void OnDisable()
        {
            if (m_instantiateEnemy != null)
                Detach(m_instantiateEnemy);
        }
        //input to check if the TakeDamage() and NotifyObserver() works
        private void Update()
        {
            if (m_health <= 0)
            {
                EnemyCount--;
                NotifyObserver();
                Destroy(this.gameObject);
                m_canBeAttacked = false;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                TakeDamage(5);
            }
        }
        
        public void TakeDamage(int damage)
        {
            if(m_health > 0 && m_canBeAttacked == true)
            {
                m_health -= damage;
                if(m_health <= 0)
                {
                    EnemyCount--;
                    NotifyObserver();
                    Destroy(this.gameObject);
                    m_canBeAttacked = false;
                }
            }

            /*if(m_health <= 0 && m_canBeAttacked == true)
            {
                EnemyCount--;
                NotifyObserver();
                Destroy(this.gameObject);
                m_canBeAttacked = false;
            }*/
        }
    }
}

