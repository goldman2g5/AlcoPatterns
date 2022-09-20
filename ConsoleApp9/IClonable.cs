using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication3
{
    public interface IClonable
    {
        IClonable Clone();
        
        virtual object DeepCopy()
        {
            object copy = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));
 
                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);
 
                copy = binFormatter.Deserialize(tempStream);
            }
            return copy;
        }
    }
}