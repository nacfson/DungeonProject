using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
    private int hp;
    public int maxHP;
    public float accleration;
    public float deAccleration;
    public int damage;
    public float viewDistance;
    public float attackDistance;

    public float attackDelay;
}
