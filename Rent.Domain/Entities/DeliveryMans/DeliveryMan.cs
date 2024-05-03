using Rent.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Entities.DeliveryMans
{
    public class DeliveryMan : BaseEntity
    {
        public string Identifier { get; private set; }
        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string CNH { get; private set; }
        public CNHTypeEnum TypeCNH { get; private set; }
        public string CNHImagePath { get; private set; }

        private static List<string> RegisteredCNPJs = new List<string>();
        private static List<string> RegisteredCNHNumbers = new List<string>();

        public DeliveryMan(string identifier, string name, string cnpj, DateTime birthDate, string cnh, CNHTypeEnum typeCNH, string urlImageCNH)
        {
            if (RegisteredCNPJs.Contains(cnpj))
                Alert("CNPJ já está registrado.");

            if (RegisteredCNHNumbers.Contains(cnh))
                Alert("Número da CNH já está registrado.");

            Identifier = identifier;
            Name = name;
            CNPJ = cnpj;
            BirthDate = birthDate;
            CNH = cnh;
            TypeCNH = typeCNH;
            CNHImagePath = urlImageCNH;

            RegisteredCNPJs.Add(CNPJ);
            RegisteredCNHNumbers.Add(CNH);
        }

        public void ChangeUrlImageCNH(string imagePath)
        {
            ValidateImageFormat(imagePath);

            CNHImagePath = imagePath;
        }

        private void ValidateImageFormat(string filePath)
        {
            string[] validFormats = { ".png", ".bmp" };
            string fileExtension = Path.GetExtension(filePath).ToLower();

            if (!validFormats.Contains(fileExtension))
                Alert("Invalid image format. Only PNG and BMP are supported.");
        }


        public static bool ValidateCNHType(CNHTypeEnum type)
        {
            return type == CNHTypeEnum.A || type == CNHTypeEnum.B || type == CNHTypeEnum.AB;
        }
    }
}
