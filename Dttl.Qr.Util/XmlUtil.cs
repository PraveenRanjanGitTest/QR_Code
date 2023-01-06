using System.Xml.Serialization;

namespace Dttl.Qr.Util
{
    /// <summary>
    ///   This class has the utility functions for xml Hanlding
    /// </summary>
    public static class XmlUtil
    {
        /// <summary>Serializes the object.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static string SerializeObject<T>(this T objectToSerialize)
        {
            XmlSerializer xmlSerializer = new(objectToSerialize!.GetType());

            using StringWriter textWriter = new();
            xmlSerializer.Serialize(textWriter, objectToSerialize);
            return textWriter.ToString();
        }
    }
}