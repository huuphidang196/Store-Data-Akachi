using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : SurMonoBehaviour
{
    [Header("Spawner")]

    [SerializeField] protected Transform _holder;
    public Transform  Holder => _holder;

    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;

    [SerializeField] protected List<Transform> prefabs;
    public List<Transform> Prefabs => prefabs;

    [SerializeField] protected List<Transform> poolObjs;
   // public List<Transform> PoolObjs => poolObjs;

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadPrefabs()
    {
        //Chống reset nhiều lần, vì có hàm awake cha đã reset chống quên action reset con
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = this.transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
    }

    protected virtual void LoadHolder()
    {
        if (this._holder != null) return;
        this._holder = this.transform.Find("Holder");
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }


    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        //Name => get by name => get pool nếu có return. ko có tạo mới return
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.Log("Prefab not found : " + prefab.name);
            return null;
        }

        return this.Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.SetParent(this._holder);
        this.spawnedCount++;

        return newPrefab;
    }


    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }


    protected virtual Transform GetObjectFromPool(Transform prefab)
    {

        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;

        if (obj.parent != this._holder) obj.parent = this._holder;
    }


    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return prefabs[rand];
    }

}
