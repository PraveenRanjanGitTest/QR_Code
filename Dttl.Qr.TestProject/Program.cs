// See https://aka.ms/new-console-template for more information
using Dttl.Qr.Model;
using Dttl.Qr.Util;

string fileName = "ProfilePhoto.jpg";

VCardQRCode c = new()
{
    FirstName = "Praveen",
    LastName = "Ranjan",
    CompanyName = "Kanini",
    Designation = "Software Developer",
    MobileNo = "9000000000",
    EmailId = "Test@kanini.com",
    Website = "kanini.com",
    PersonalLinks = "www.google.com",
    UploadImage = fileName
};

// Test

File.WriteAllText("Vcard.vcf", VCardUtil.GetVCard(c));