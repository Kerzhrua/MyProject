using MyProject.设计模式.生成器模式.生成的物品;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.设计模式.生成器模式.指挥部
{
    class Director
    {

        private AbsBuilder absbuilder;
        public void setBuilder(AbsBuilder builder)
        {
            this.absbuilder = builder;
        }

        public BuildItem getAItem()
        {
            constractItem();
            return absbuilder.getItem();
        }
        public BuildItem getBItem()
        {
            constractItem();
            return absbuilder.getItem();
        }

        public void constractItem()
        {
            absbuilder.buildPart1();
            absbuilder.buildPart2();
            absbuilder.buildPart3();
            absbuilder.buildPart4();
            absbuilder.buildPart5();
        }

    }
}
