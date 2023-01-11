using Dttl.Qr.Model;
using System.Text;

namespace Dttl.Qr.Util
{
    /// <summary>
    ///   Class has the utility functions related to VCard format
    /// </summary>
    public static class VCardUtil
    {
        /// <summary>Gets the profile photo.</summary>
        /// <param name="vCardModel">The v card model.</param>
        /// <returns>
        ///   string format of the Profile Photo
        /// </returns>
        private static string GetProfilePhoto(VCardQRCode vCardModel)
        {
            if (vCardModel == null) return string.Empty;

            if (vCardModel.UploadImage == null) return string.Empty;

            return vCardModel.UploadImage;
        }

        /// <summary>Gets the v card.</summary>
        /// <param name="vCardModel">The v card model.</param>
        /// <returns>
        ///   the string format of the VCard
        /// </returns>
        public static string GetVCard(VCardQRCode vCardModel)
        {
            if (vCardModel == null) return string.Empty;
            var builder = new StringBuilder();
            builder.AppendLine("BEGIN:VCARD").AppendLine("VERSION:2.1");

            // Name
            builder.Append("N:").Append(vCardModel.LastName)
              .Append(';').AppendLine(vCardModel.FirstName);

            // Full name
            builder.Append("FN:").Append(vCardModel.FirstName)
              .Append(' ').AppendLine(vCardModel.LastName);

            // Other data
            builder.Append("ORG:").AppendLine(vCardModel.CompanyName);
            builder.Append("TITLE:").AppendLine(vCardModel.Designation);
            builder.Append("TEL;WORK;VOICE:").AppendLine(vCardModel.MobileNo);
            builder.Append("TEL;CELL;VOICE:").AppendLine(vCardModel.MobileNo);
            builder.Append("URL;VTYPE=PREF:").AppendLine(vCardModel.PersonalLinks);
            builder.Append("EMAIL;type=INTERNET;type=WORK;TYPE=PREF:").AppendLine(vCardModel.EmailId);
            builder.Append("PHOTO;ENCODING=BASE64;TYPE=JPEG:").AppendLine(GetProfilePhoto(vCardModel));

            builder.AppendLine("END:VCARD");
            return builder.ToString();
        }
    }
}