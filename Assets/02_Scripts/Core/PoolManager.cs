using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static PoolManager Instance = null;

    private Dictionary<string, Pool<PoolAbleMono>> _pools = new Dictionary<string, Pool<PoolAbleMono>>();
    //Ű��� ��� ����

    public Transform _trmParent;
    public PoolManager(Transform trmParent)
    {
        _trmParent = trmParent;
    }

    public void Push(PoolAbleMono obj)
    {
        if (_pools.ContainsKey(obj.gameObject.name))
        {
            _pools[obj.gameObject.name].Push(obj);

        }
        else
        {
            Debug.LogError($"{obj.gameObject.name}�� Ǯ�� �������� �ʽ��ϴ�.");
        }
    }
    public PoolAbleMono Pop(string objName)
    {
        if (_pools.ContainsKey(objName) == false)
        {
            Debug.LogError($"{objName}�� Ǯ�� �������� �ʽ��ϴ�.");
            return null;
        }

        PoolAbleMono item = _pools[objName].Pop();
        item.Init();
        return item;
    }

    public void CreatePool(PoolAbleMono prefab, int count = 10)
    {
        Pool<PoolAbleMono> pool = new Pool<PoolAbleMono>(prefab, _trmParent, count);
        _pools.Add(prefab.gameObject.name, pool);
        //dictionary �� �������� �̸����� pool�� ����Ѵ�.
    }
}
