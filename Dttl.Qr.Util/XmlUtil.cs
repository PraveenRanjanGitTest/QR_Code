using System.Xml.Serialization;

namespace Dttl.Qr.Util
{
    public static class XmlUtil
    {
        public static string SerializeObject<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new(toSerialize!.GetType());

            using StringWriter textWriter = new();
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }
    }
}