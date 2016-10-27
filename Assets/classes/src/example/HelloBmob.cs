using UnityEngine;
using cn.bmob.api;
using cn.bmob.tools;

public class HelloBmob : MonoBehaviour {

    private static BmobUnity Bmob;

    // Use this for initialization
    void Start()
    {
        BmobDebug.Register(print);
        BmobDebug.level = BmobDebug.Level.TRACE;
        Bmob = GetComponent<BmobUnity>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            createData_Click();
        }
    }


    //对应要操作的数据表
    public const string TABLE_NAME = "Score";
    //接下来要操作的数据的数据
    private cn.bmob.example.GameObject gameObject = new cn.bmob.example.GameObject(TABLE_NAME);



    private void createData_Click()
    {
        //设置值    
        gameObject.score =100;

        Bmob.Create("Score", gameObject, (resp, exception) =>
        {
            if (exception != null)
            {
                Debug.Log("保存失败，失败原因" + exception.Message);
                return;
            }
            Debug.Log("保存成功" + resp.createdAt);
        });


        //保存数据
        //var future = Bmob.  CreateTaskAsync(gameObject);
        //异步显示返回的数据
        //FinishedCallback(future.Result, resultText);


        //var data = new BmobScore();
        //int score = 100;
        //data.score = score;

        //Bmob.Create("Score", data, (resp, exception) =>
        //{
        //    if (exception != null)
        //    {
        //        Debug.Log("保存失败，失败原因" + exception.Message);
        //        return;
        //    }
        //    Debug.Log("保存成功" + resp.createdAt);
        //});

    }
}
