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
                //  if(prisonerDto.Mails.Any(x=>x.))


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

            return "";
            var xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            StringBuilder sb=new StringBuilder();

            List<Officer> validOfficers = new List<Officer>();

            foreach (var el in elements)
            {
                string name = el.Element("Name")?.Value;
                decimal money = decimal.Parse(el.Element("Money")?.Value);
                string position = el.Element("Position")?.Value;
                string weapon = el.Element("Weapon")?.Value;
                int departmentId = int.Parse(el.Element("DepartmentId")?.Value);
                var prisoners = el.Element("Prisoners")?.Elements();

                Position newPosition = Enum.Parse<Position>(position);
                Weapon newWeapon = Enum.Parse<Weapon>(weapon);

                


                List<PrisonerIdDto> newPrisoners = new List<PrisonerIdDto>();

                foreach (var p in prisoners)
                {
                    PrisonerIdDto newP = new PrisonerIdDto();

                    newPrisoners.Add(newP);
                }

                List<Prisoner> existingPrisoners = new List<Prisoner>();

                foreach (var p in newPrisoners)
                {
                    Prisoner prisoner = context.Prisoners.FirstOrDefault(x => x.Id == p.Id);

                    existingPrisoners.Add(prisoner);
                }

                Officer officer = new Officer
                {
                    FullName = name,
                    Salary = money,
                    Position = newPosition,
                    Weapon = newWeapon,
                    DepartmentId = departmentId,
                    OfficerPrisoners = new List<OfficerPrisoner>()
                };

                List<OfficerPrisoner> newOfficerPrisoners = new List<OfficerPrisoner>();

                foreach (var op in newPrisoners)
                {
                    OfficerPrisoner newOP = new OfficerPrisoner
                    {
                        Officer = officer,
                        OfficerId = officer.Id,
                        Prisoner = context.Prisoners.FirstOrDefault(x => x.Id == op.Id),
                        PrisonerId = op.Id
                    };

                    newOfficerPrisoners.Add(newOP);
                }

                officer.OfficerPrisoners = newOfficerPrisoners;

                if (!IsValid(officer))
                   {
                       sb.AppendLine(FailureMessage);
                       continue;
                   }

                validOfficers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

            // var serializer = new XmlSerializer(typeof(OfficerDto[]), new XmlRootAttribute("Officers"));
            // var deserializedOfficerDtos = (OfficerDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            //
            // List<Officer> validOfficers=new List<Officer>();
            //
            // StringBuilder sb= new StringBuilder();
            //
            //
            // foreach (var officerDto in deserializedOfficerDtos)
            // {
            //    //foreach (var op in officerDto.OfficerPrisoners)
            //    //{
            //    //    Console.WriteLine(op.PrisonerId);
            //    //}
            //
            //
            //     if (!IsValid(officerDto))
            //     {
            //         sb.AppendLine(FailureMessage);
            //         continue;
            //     }
            //
            //     Position position = Enum.Parse<Position>(officerDto.Position);
            //     Weapon weapon = Enum.Parse<Weapon>(officerDto.Weapon);
            //
            //     Officer officer=new Officer
            //     {
            //         FullName=officerDto.FullName,
            //         Salary = officerDto.Salary,
            //         Position = position,
            //         Weapon = weapon,
            //         DepartmentId = officerDto.DepartmentId,
            //        // OfficerPrisoners = new List<OfficerPrisoner>()
            //     };
            //
            //     List<OfficerPrisoner> newOfficerPrisoners=new List<OfficerPrisoner>();
            //
            //     
            //
            //     validOfficers.Add(officer);
            //     sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            // }
            //
            // context.Officers.AddRange(validOfficers);
            // context.SaveChanges();
            // return sb.ToString().TrimEnd();
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