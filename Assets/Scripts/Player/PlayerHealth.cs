using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int m_health = 100;
        public void TakeDamage(int damage)
        {
            m_health -= damage;
        }
    }
}