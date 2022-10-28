using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.设计模式.生成器模式.生成器.具体生成器
{
    class BBuilder : AbsBuilder
    {
        public override void buildPart1()
        {
            Console.WriteLine("B build part1!!");
        }

        public override void buildPart2()
        {
            Console.WriteLine("B build part2!!");
        }

        public override void buildPart3()
        {
            Console.WriteLine("B build part3!!");
        }

        public override void buildPart4()
        {
            Console.WriteLine("B build part4!!");
        }

        public override void buildPart5()
        {
            Console.WriteLine("B build part5!!");
        }
    }
}
