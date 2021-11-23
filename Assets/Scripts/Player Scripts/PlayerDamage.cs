using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public LayerMask enemyLayer;
    public EnemyHealth enemyHealthScript;

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 0.1f, enemyLayer);

        if (hits.Length > 0) {
            if (hits[0].gameObject.tag == MyTags.ENEMY_TAG) {
                enemyHealthScript = hits[0].GetComponent<EnemyHealth>();

                hits[0].gameObject.GetComponent<EnemyHealth>().ApplyDamage(damageAmount);

                // SoundManager.instance.PlayDamageSound();
            }
        }
    }
}
