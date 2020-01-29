using Defiance.Bolton.Domain.Entities;
using Defiance.Bolton.Domain.Exceptions;
using System;
using System.Text;
using System.Xml;

namespace Defiance.Bolton.Infrastructure.Arquivei.Helpers
{
    public static class Base64ToNFeHelper
    {
        public static EletronicTaxInvoice FromBase64(this string base64)
        {
            if (string.IsNullOrEmpty(base64))
                throw new ArgumentNullException(nameof(base64));

            var xmlDoc = new XmlDocument();

            var xml = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
            xmlDoc.LoadXml(xml);

            try
            {
                var infNfe = xmlDoc.DocumentElement["infNFe"] ?? xmlDoc.DocumentElement.FirstChild["infNFe"];
                var key = infNfe.Attributes["Id"].Value.Replace("NFe", string.Empty);

                var date = infNfe["ide"]["dhEmi"] == null
                    ? DateTime.Parse(infNfe["ide"]["dEmi"].InnerText)
                    : DateTime.Parse(infNfe["ide"]["dhEmi"].InnerText);

                var issuer = infNfe["emit"]["CNPJ"].InnerText;
                var recipient = infNfe["dest"]["CNPJ"].InnerText;
                var total = decimal.Parse(infNfe["total"]["ICMSTot"]["vNF"].InnerText);

                return EletronicTaxInvoice.Build(key, date, issuer, recipient, total);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException($"Error processing XML: {xml}, error: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
        }
    }
}
