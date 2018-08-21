using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{
    using Data;
    using System;

    public class Deserializer
    {
        private static string SuccessMessage = "Imported {0} with {1} cells";
        private static string FailureMessage = "Invalid Data";


        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            DepartmentDto[] departmentDtos = JsonConvert.DeserializeObject<DepartmentDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Department> validDepartments = new List<Department>();

            foreach (var departmentDto in departmentDtos)
            {
                List<Cell> validCells = new List<Cell>();
                bool cellIsGood = true;

                if (departmentDto.Cells.Any(x => x.CellNumber < 1 || x.CellNumber > 1000))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Department department = new Department
                {
                    Cells = departmentDto.Cells,
                    Name = departmentDto.Name
                };

                validDepartments.Add(department);
                int cellCount = department.Cells.Count;
                sb.AppendLine($"Imported {department.Name} with {cellCount} cells");

            }

            context.AddRange(validDepartments);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            PrisonerDto[] departmentDtos = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in departmentDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Prisoner prisoner = new Prisoner
                {
                    Age = prisonerDto.Age,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    FullName = prisonerDto.FullName,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Mails = prisonerDto.Mails,
                    Nickname = prisonerDto.Nickname
                };

                if (prisonerDto.ReleaseDate != null)
                {
                    prisoner.ReleaseDate = DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                }

                validPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }
            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OfficerDto[]), new XmlRootAttribute("Officers"));
            var dtos = (OfficerDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();
            var officers = new List<Officer>();
            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var isValidPosition = Enum.TryParse(typeof(Position), dto.Position, out object positionResult);
                var isValidWeapon = Enum.TryParse(typeof(Weapon), dto.Weapon, out object weaponResult);

                if (!isValidPosition || !isValidWeapon)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var position = (Position)positionResult;
                var weapon = (Weapon)weaponResult;

                var officersPrisoners = new List<OfficerPrisoner>();
                foreach (var prisoner in dto.Prisoners)
                {
                    var officerPrisoner = new OfficerPrisoner
                    {
                        PrisonerId = prisoner.Id
                    };

                    officersPrisoners.Add(officerPrisoner);
                }

                var officer = new Officer
                {
                    FullName = dto.FullName,
                    Salary = dto.Salary,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = dto.DepartmentId,
                    OfficerPrisoners = officersPrisoners
                };

                officers.Add(officer);

                sb.AppendLine(String.Format(SuccessMessage, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}