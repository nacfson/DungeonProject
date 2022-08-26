using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public Transform Player { get => _player; }
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private PoolingListSO _poolingListSO;

    public int mobCount;

    public UnityEvent Faze1;
    public UnityEvent Faze2;
    public UnityEvent Faze3;
    public UnityEvent Faze4;
    public UnityEvent Faze5;


    public Player player;
    private void Awake()
    {
        PoolManager.Instance = new PoolManager(transform);
        CreatePool();
        StartCoroutine(CheckMobCount());
    }
    private void CreatePool()
    {
        foreach(PoolingPair pp in _poolingListSO.list)
        {
            PoolManager.Instance.CreatePool(pp.prefab, pp.poolCount);
        }
    }
    IEnumerator CheckMobCount()
    {
        while(true)
        {
            if(mobCount >= 20)
            {
                Debug.Log("Faze2");
                Faze2?.Invoke();
            }
        }
    }

}
