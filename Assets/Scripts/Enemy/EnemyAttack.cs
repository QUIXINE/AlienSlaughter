using Player;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int m_damage = 10;
    private void OnTriggerEnter(Collider col)
    {
        PlayerHealth playerHealth = col.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(m_damage);
        }    
    }
}
