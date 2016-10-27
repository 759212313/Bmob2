using UnityEngine;
using System.Collections;
using cn.bmob.io;

public class EntityData : BmobTable {

    public string name { get; set; }
    public string hp { get; set; }
    public string apk { get; set; }

    //读字段信息
    public override void readFields(BmobInput input)
    {
        base.readFields(input);
        this.name = input.getString("Name");
        this.hp = input.getString("Hp");
        this.apk = input.getString("Apk");
    }

    //写字段信息
    public override void write(BmobOutput output, bool all)
    {
        base.write(output, all);
        output.Put("Name", this.name);
        output.Put("Hp", this.hp);
        output.Put("Apk", this.apk);
    }
}
