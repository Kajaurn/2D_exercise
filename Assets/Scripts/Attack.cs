using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            //调整被击退方向与朝向方向一致
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            //造成伤害
            bool gotHit= damageable.Hit(attackDamage,deliveredKnockback);
            if (gotHit)
            {
                Debug.Log(collision.name + "hit for" + attackDamage);
            }
        }
    }
}
