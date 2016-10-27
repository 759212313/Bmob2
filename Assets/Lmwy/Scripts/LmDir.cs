using UnityEngine;
using System.Collections;
using cn.bmob.api;
using cn.bmob.tools;
using UnityEngine.UI;
using cn.bmob.io;
using System.Collections.Generic;

public class LmDir : MonoBehaviour {

    private static BmobUnity bmobUnity;
    public InputField title;
    public InputField content;

    public List<ContentMode> lists = new List<ContentMode>();
    public ArtMng artMng;
    public GameObject editorPage;

    void Awake()
    {
        BmobDebug.Register(print);
        BmobDebug.level = BmobDebug.Level.TRACE;
        bmobUnity = GetComponent<BmobUnity>();
    }

    void Start()
    {
        RefreshList();
    }

    public void createData_Click()
    {
        var data = new ContentMode();
        data.title = title.text;
        data.content = content.text;

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

    public void RefreshList()
    {
        //创建一个BmobQuery查询对象
        BmobQuery query = new BmobQuery();
        query.Limit(10);
        bmobUnity.Find<ContentMode>("Content", query, (resp, exception) =>
        {
            if (exception != null)
            {
                print("查询失败, 失败原因为： " + exception.Message);
                return;
            }
            lists.Clear();
            lists = resp.results;
            artMng.Refresh(lists);
        });
    }

    public void NewBtn()
    {
        editorPage.gameObject.SetActive(true);
    }

    public void CloseEditor()
    {
        editorPage.gameObject.SetActive(false);
    }
}
