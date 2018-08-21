using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.DataProcessor.ExportDto;
using SoftJail.DataProcessor.ImportDto;
using PrisonerDto = SoftJail.DataProcessor.ExportDto.PrisonerDto;

namespace SoftJail.DataProcessor
{
    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners.Where(x => ids.Any(p => p == x.Id)).Include(p => p.PrisonerOfficers)
                .ThenInclude(op => op.Officer)
                .ThenInclude(o => o.Department)
                .Select(i => new
                {
                    Id = i.Id,
                    Name = i.FullName,
                    CellNumber = i.Cell.CellNumber,
                    Officers = i.PrisonerOfficers.Select(o => new OfficersDto
                        {
                            OfficerName = o.Officer.FullName,
                            Department = o.Officer.Department.Name
                        })
                        .OrderBy(o=>o.OfficerName)
                        .ToArray()
                })
                .OrderBy(x=>x.Name)
                .ThenByDescending(x=>x.Id)
                .ToArray();

            string result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return result;
        }


        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] names = prisonersNames.Split(',');

            var prisoners = context.Prisoners.Where(x => names.Any(p => p == x.FullName))
                .Select(o => new
                {
                    Id = o.Id,
                    Name = o.FullName,
                    IncarcerationDate = o.IncarcerationDate,
                    EncryptedMessafes = o.Mails.Select(m => new
                    {
                        Description = m.Description
                    }).ToArray()
                })
                .OrderBy(x=>x.Name)
                .ThenByDescending(x=>x.Id)
                .ToArray();


            var xDoc = new XDocument(new XElement("Prisoners"));


            foreach (var p in prisoners)
            {
                xDoc.Root.Add
                    (
                    new XElement("Prisoner",
                        new XElement("Id", p.Id),
                        new XElement("Name", p.Name),
                        new XElement("IncarcerationDate", p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
                        new XElement("EncryptedMessages", p.EncryptedMessafes.Select(m=>
                        new XElement("Message",
                        new XElement("Description", m.Description.Reverse()))))
                    )
                    );
            }

            string result = xDoc.ToString();
            return result;
        }
    }
}