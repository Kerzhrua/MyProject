using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.设计模式.生成器模式.生成器.具体生成器
{
    public class ABuilder : AbsBuilder
    {
        public override void buildPart1()
        {
            Console.WriteLine("A build part1!!");
        }

        public override void buildPart2()
        {
            Console.WriteLine("A build part2!!");
        }

        public override void buildPart3()
        {
            Console.WriteLine("A build part3!!");
        }

        public override void buildPart4()
        {
            Console.WriteLine("A build part4!!");
        }

        public override void buildPart5()
        {
            Console.WriteLine("A build part5!!");
        }
    }
}
