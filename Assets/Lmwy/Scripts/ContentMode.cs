using UnityEngine;
using System.Collections;
using cn.bmob.io;

public class ContentMode : BmobTable
{
    public string title { get; set; }
    public string content { get; set; }

    //读字段信息
    public override void readFields(BmobInput input)
    {
        base.readFields(input);
        this.title = input.getString("Title");
        this.content = input.getString("Content");
    }

    //写字段信息
    public override void write(BmobOutput output, bool all)
    {
        base.write(output, all);
        output.Put("Title", this.title);
        output.Put("Content", this.content);
    }
}
