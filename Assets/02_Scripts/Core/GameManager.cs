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
        mobCount = 0;
        PoolManager.Instance = new PoolManager(transform);
        CreatePool();
        StartCoroutine(CheckMobCount2());
    }
    private void CreatePool()
    {
        foreach(PoolingPair pp in _poolingListSO.list)
        {
            PoolManager.Instance.CreatePool(pp.prefab, pp.poolCount);
        }
    }
    IEnumerator CheckMobCount2()
    {
        while(true)
        {
            if(mobCount >= 20)
            {
                Debug.Log("Faze2");
                Faze2?.Invoke();
            }
            yield return null;
        }
    }
    public IEnumerator CheckMobCount3()
    {
        while(true)
        {
            if(mobCount >= 32)
            {
                Debug.Log("Faze3");
                Faze3?.Invoke();
            }
            yield return null;
        }
    }
    public void StartCoroutineName(string corName)
    {
        StartCoroutine(corName);
    }
    public IEnumerator CheckMobCount4()
    {
        while(true)
        {
            if(mobCount >= 90)
            {
                Debug.Log("Faze2");
                Faze4?.Invoke();
            }
            yield return null;
        }
    }
    public static double VectorToDegree(Vector2 vector)
{
    double radian = Mathf.Atan2(vector.y, vector.x);
    return (radian*180.0/Mathf.PI);
}

}
