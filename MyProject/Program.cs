using System;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //  序列化相关  二进制序列化与反序列化
            BinSerialize();
            //  序列化相关  Json序列化与反序列化
            JsonSerialize();
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