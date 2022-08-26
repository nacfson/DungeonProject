using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject _healItem;


    private int randomInt;
    public void DropItem()
    {
        randomInt = Random.Range(1,22);
        if(randomInt > 21)
        {
            Instantiate(_healItem,transform.position,Quaternion.identity);
        }
    }
}
