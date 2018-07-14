using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfiiguration
{
   public class BankAccountConfig: IEntityTypeConfiguration<BankAccount>
   {
       public void Configure(EntityTypeBuilder<BankAccount> builder)
       {
           builder.HasOne(x => x.PaymentMethod)
               .WithOne(x => x.BankAccount)
               .HasForeignKey<PaymentMethod>(x => x.BankAccountId);
        }
   }
}
