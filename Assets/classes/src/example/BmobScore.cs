using UnityEngine;
using System.Collections;
using cn.bmob.io;

//Game表对应的模型类
public class BmobScore : BmobTable
{

    //以下对应云端字段名称
    public BmobInt score { get; set; }

    //读字段信息
    public override void readFields(BmobInput input)
    {
        base.readFields(input);
        this.score = input.getInt("Score");
    }

    //写字段信息
    public override void write(BmobOutput output, bool all)
    {
        base.write(output, all);
        output.Put("Score", this.score);
    }
}
