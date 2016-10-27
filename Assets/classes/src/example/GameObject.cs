using cn.bmob.io;
using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cn.bmob.example
{
    //Game表对应的模型类
    class GameObject : BmobTable
    {

        private String fTable;
        //以下对应云端字段名称
        public BmobInt score { get; set; }

        //构造函数
        public GameObject() { }

        //构造函数
        public GameObject(String tableName)
        {
            this.fTable = tableName;
        }

        public override string table
        {
            get
            {
                if (fTable != null)
                {
                    return fTable;
                }
                return base.table;
            }
        }

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
}
