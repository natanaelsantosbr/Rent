using Rent.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Entities.DeliveryMen
{
    public class DeliveryMan : BaseEntity
    {
        protected DeliveryMan() { }

        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string CNH { get; private set; }
        public CNHTypeEnum TypeCNH { get; private set; }
        public string Email { get; private set; }
        public string CNHImagePath { get; private set; }

        public DeliveryMan(string name, string cnpj, DateTime birthDate, string cnh, CNHTypeEnum typeCNH, string email, string cnhImagePath)
        {
            Name = name;
            CNPJ = cnpj;
            BirthDate = birthDate;
            CNH = cnh;
            TypeCNH = typeCNH;
            Email = email;
            CNHImagePath = cnhImagePath;

            Validate();
        }

        public void UpdateCNHImagePath(string imagePath)
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

        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                Alert("Name is required.");

            if (string.IsNullOrEmpty(CNPJ) || !IsValidCNPJ(CNPJ))
                Alert("A valid CNPJ is required.");

            if (string.IsNullOrEmpty(CNH))
                Alert("CNH number is required.");

            if ((TypeCNH != CNHTypeEnum.A && TypeCNH != CNHTypeEnum.B && TypeCNH != CNHTypeEnum.AB))
                Alert("Type CNH must be 'A', 'B', or 'A+B'.");
        }

        private bool IsValidCNPJ(string cnpj)
        {
            return true;   
        }

        public bool CanRent()
        {
            return TypeCNH == CNHTypeEnum.A || TypeCNH == CNHTypeEnum.AB;
        }
    }
}
