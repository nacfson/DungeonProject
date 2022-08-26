using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Player { get => _player; }
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private PoolingListSO _poolingListSO;


    public Player player;

/// <summary>
/// Awake is called when the script instance is being loaded.
/// </summary>
private void Awake()
{
    PoolManager.Instance = new PoolManager(transform);
    CreatePool();
}
    private void CreatePool()
    {
        foreach(PoolingPair pp in _poolingListSO.list)
        {
            PoolManager.Instance.CreatePool(pp.prefab, pp.poolCount);
        }
    }
}
