using UnityEngine;
using System.Collections;
using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.tools;
using System.Collections.Generic;
using System;

public class GameDir : Singleton<GameDir> {

    public BmobUnity bmobUnity { get; set; }
    public List<EntityData> enLists;

    void Awake()
    {
        BmobDebug.Register(print);
        BmobDebug.level = BmobDebug.Level.TRACE;
        bmobUnity = GetComponent<BmobUnity>();
    }

    void Start()
    {
        RefreshData(null);
    }

    public void SaveData(EntityData data)
    {
        bmobUnity.Create("Content", data, (resp, exception) =>
        {
            if (exception != null)
            {
                Debug.Log("保存失败，失败原因" + exception.Message);
                return;
            }
            Debug.Log("保存成功" + resp.createdAt);
        });
    }

    public void RefreshData(Action<List<EntityData>> callBack)
    {
        BmobQuery query = new BmobQuery();
        query.Limit(10);
        bmobUnity.Find<EntityData>("Content", query, (resp, exception) =>
        {
            if (exception != null)
            {
                print("查询失败, 失败原因为： " + exception.Message);
                return;
            }
            enLists.Clear();
            enLists = resp.results;
            if (callBack != null)
            {
                callBack(enLists);
            }
        });
    }
}
