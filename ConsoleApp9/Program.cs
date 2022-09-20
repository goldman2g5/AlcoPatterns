using System;
using System.IO;

namespace ConsoleApp9
{
    class Program
    {
        public interface IClonable
        {
            public object DeepCopy()
            {
                object figure = null;
                using (MemoryStream tempStream = new MemoryStream())
                {
                    BinaryFormatter binFormatter = new BinaryFormatter(null,
                        new StreamingContext(StreamingContextStates.Clone));

                    binFormatter.Serialize(tempStream, this);
                    tempStream.Seek(0, SeekOrigin.Begin);

                    figure = binFormatter.Deserialize(tempStream);
                }
                return figure;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
