using Rent.Domain.Abstractions.Entities;

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
            int[] firstMultiplier = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] secondMultiplier = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * firstMultiplier[i];

            int remainder = (sum % 11);

            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            string digit = remainder.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;

            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * secondMultiplier[i];

            remainder = (sum % 11);

            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digit = digit + remainder.ToString();

            return cnpj.EndsWith(digit);
        }


        public bool CanRent()
        {
            return TypeCNH == CNHTypeEnum.A || TypeCNH == CNHTypeEnum.AB;
        }
    }
}
