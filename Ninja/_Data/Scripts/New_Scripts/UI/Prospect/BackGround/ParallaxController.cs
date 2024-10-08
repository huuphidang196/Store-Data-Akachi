using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : SurMonoBehaviour
{
    [SerializeField] protected Transform _MainCamera;
    [SerializeField] protected Vector3 _Cam_Start_Pos;
    [SerializeField] protected float _Distance;

    [SerializeField] protected List<Transform> _List_Elements_BG;
    [SerializeField] protected List<Material> _List_Material;
    [SerializeField] protected List<float> _List_BackSpeed;

    [SerializeField] protected float _FarthestBack;

    [Range(0.03f, 0.1f)]
    public float _Parallax_Speed = 0.07f;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadListElementsBackGround();
    }

    protected virtual void LoadListElementsBackGround()
    {
        if (this._List_Elements_BG.Count > 0) return;

        foreach (Transform item in this.transform)
        {
            this._List_Elements_BG.Add(item);

            Material mat = item.GetComponent<Renderer>().material;
            this._List_Material.Add(mat);
        }
    }

    protected override void Start()
    {
        base.Start();

        this._MainCamera = Camera.main.transform;
        this._Cam_Start_Pos = this._MainCamera.position;

        this.BackSpeedCalculate();
    }

    protected virtual void BackSpeedCalculate()
    {
        for (int i = 0; i < this._List_Elements_BG.Count; i++)
        {
            if ((this._List_Elements_BG[i].transform.position.z - this._MainCamera.position.z) <= this._FarthestBack) continue;

            this._FarthestBack = this._List_Elements_BG[i].transform.position.z - this._MainCamera.position.z;
        }

        for (int i = 0; i < this._List_Elements_BG.Count; i++)
        {
            float backSi = 1 - (this._List_Elements_BG[i].transform.position.z - this._MainCamera.position.z) / this._FarthestBack;
            this._List_BackSpeed.Add(backSi);
        }
    }

    protected virtual void LateUpdate()
    {
        this._Distance = this._MainCamera.position.x - this._Cam_Start_Pos.x;
        this.transform.position = new Vector3(this._MainCamera.position.x, this.transform.position.y, 0);

        for (int i = 0; i < this._List_Elements_BG.Count; i++)
        {
            float speed = this._List_BackSpeed[i] * this._Parallax_Speed;
            this._List_Material[i].SetTextureOffset("_MainTex", new Vector2(this._Distance, 0) * speed);
        }

    }
}
