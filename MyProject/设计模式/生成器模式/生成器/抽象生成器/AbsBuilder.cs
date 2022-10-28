using MyProject.设计模式.生成器模式.生成的物品;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.设计模式.生成器模式
{
    public abstract class AbsBuilder
    {
        protected BuildItem buildItem;

        public BuildItem getItem()
        {
            return buildItem;
        }

        public void BuildItem()
        {
            buildItem = new 生成的物品.BuildItem();
            Console.WriteLine("build item!!");
        }
        public abstract void buildPart1();
        public abstract void buildPart2();
        public abstract void buildPart3();
        public abstract void buildPart4();
        public abstract void buildPart5();


    }
}
