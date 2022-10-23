using System;
using System.IO;
using System.Text;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Financial;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MyProject
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //  序列化相关  二进制序列化与反序列化
        //    BinSerialize();
        //    //  序列化相关  Json序列化与反序列化
        //    JsonSerialize();
        //}

        static void Main(string[] args)
        {
            //  矩阵可以是密集的、对角的或稀疏的
            //  创建一个 3X4 随机值矩阵
            Matrix<double>.Build.Random(3, 4);
            //  创建一个 3X4 矩阵用1填充
            Matrix<double>.Build.Dense(3, 4, 1.0);
            //  从已有数组创建
            double[] x = new double[12];  //  注意下面是 3X4 这个长度就得是12
            Matrix<double> Mx = Matrix<double>.Build.Dense(3, 4, x);
            //  获取行、列
            var value = Mx.RowCount;
            value = Mx.ColumnCount;
            //  类似的还有这些属性
            //L1Norm（一范数）：最大绝对列总和。
            //L2Norm（二范数）：矩阵的最大奇异值（昂贵）。
            //InfinityNorm：最大绝对行总和。
            //FrobeniusNorm(矩阵的模)：每个元素的平方和再开方。
            //RowNorms（p）：每个行向量的广义p - 范数。
            //ColumnNorms（p）：每个列向量的广义p - 范数。
            Mx.RowSums();  //  每行的总和  返回Vector数组
            Mx.ColumnSums();  //  每列的总和
            //  条件数用于衡量矩阵乘法或逆的输出对输入误差的敏感性，条件数越大表明敏感性越差
            Mx.ConditionNumber();
            //  奇异矩阵  不是方阵且行列式为0(不可逆) 所表示的线性方程组有一个唯一的解。
            //Mx.Trace();  //  主对角线总和  必须是正阵才能用
            //Mx.Determinant();  //  行列式值  必须是正阵才能用
            Mx.Rank();  //  秩


            //  也许已经是某种格式了
            double[,] xx = {{ 1.0, 2.0 },
                            { 3.0, 4.0 }};
            Matrix<double>.Build.DenseOfArray(xx);  //  自动变成一个 2X2 矩阵
            //  还想用某种格式构造可以去这里面找一下对应方法
            MatrixBuilder<double> matrixBuilder = Matrix<double>.Build;

            //  矩阵算数  相乘
            //  先弄两个矩阵
            double[,] M1 = {{ 2.0, 1.0 },
                            { 4.0, 3.0 }};
            double[,] M2 = {{ 1.0, 2.0 },
                            { 1.0, 0.0 }};
            Matrix<double> matrix1 = Matrix<double>.Build.DenseOfArray(M1);
            Matrix<double> matrix2 = Matrix<double>.Build.DenseOfArray(M2);
            //  右乘
            Matrix<double> matrix3 = matrix1.Multiply(matrix2);  //  从左到右从上到下按列排在数组中
            matrix3 = matrix1 * matrix2;
            //  左乘
            Matrix<double> matrix4 = matrix2.Multiply(matrix1);
            matrix4 = matrix2 * matrix1;
            //  转置
            matrix4.Transpose();
            //  矩阵的逆
            matrix4.Inverse();

            //  数组
            Vector<double> v = Vector<double>.Build.Dense(10);

            //  线性范围
            Generate.LinearRange(10, 2, 15); // returns array { 10.0, 12.0, 14.0 }
            Generate.LinearRangeMap(10, 2, 15, Math.Sin); // applies sin(x) to each value
            //  线性间隔
            Generate.LinearSpaced(11, 0.0, 1.0); // returns array { 0.0, 0.1, 0.2, .., 1.0 }
            Generate.LinearSpacedMap(15, 0.0, 2.0, Math.Sin); // applies sin(x) to each value
            //  对数间隔
            Generate.LogSpaced(4, 0, 3); // returns array { 1, 10, 100, 1000 }

            //  克罗内克函数  相等为x否则为0
            Generate.Impulse(8, 2.0, 3);  //  长度为8，下标为3时值是2.0，其他是0
            Generate.PeriodicImpulse(8, 3, 10.0, 1);  //  [|0.0; 10.0; 0.0; 0.0; 10.0; 0.0; 0.0; 10.0|]添加周期，每三个一组下标为1的

            //  海维赛德阶跃函数  阶段前为0阶段后为x
            Generate.Step(8, 2.0, 3);  //  [|0.0; 0.0; 0.0; 2.0; 2.0; 2.0; 2.0; 2.0|] 

            //  周期性锯齿波
            Generate.PeriodicMap(15, x => x + 100, 1000.0, 100.0, 10.0, 0.0, 0);  //  [|100.0; 101.0; 102.0; 103.0; 104.0; 105.0; 106.0; 107.0; 108.0; 109.0; 100.0; 101.0; 102.0; 103.0; 104.0 |] 

            //  正弦形
            Generate.Sinusoidal(15, 1000.0, 100.0, 10.0);  //  { 0, 5.9, 9.5, 9.5, 5.9, 0, -5.9, ... }

            //  生成长度100  在0到1的均匀分布
            Generate.Uniform(100);

            //  根据方法生成新数组或序列
            var map = new double[] { 2.0, 4.0, 3.0, 6.0 };
            Generate.Map(map, x => x + 1.0); // returns array { 3.0, 5.0, 4.0, 7.0 }

            //  常用的数学和科学常数 比如Deca
            Console.WriteLine(Constants.Deca);

        }

        static void BinSerialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream;

            MyObject obj = new MyObject();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "Some String";

            //  开始序列化为二进制
            stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();

            //  二进制反序列化成对象
            stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            obj = (MyObject)formatter.Deserialize(stream);
            stream.Close();
        }


        static void JsonSerialize()
        {

            Person p = new Person();
            p.name = "John";
            p.age = 42;

            //  序列化为Json流
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer personSer = new DataContractJsonSerializer(typeof(Person));
            personSer.WriteObject(stream, p);

            //  如何读取Json流并打印
            stream.Position = 0;
            StreamReader streamReader = new StreamReader(stream);
            Console.WriteLine(streamReader.ReadToEnd());

            File.WriteAllText("readme.txt", streamReader.ReadToEnd(), Encoding.UTF8);

            //  JSON 反序列化
            stream.Position = 0;
            Person p2 = (Person)personSer.ReadObject(stream);
        }

    }
}