using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class TSAReportConfiguration : IEntityTypeConfiguration<TSAReport>
    {
        public void Configure(EntityTypeBuilder<TSAReport> builder)
        {
            builder.ConfigureBaseEntity();

            builder.HasKey(x => x.Id); // Primary Key
            builder.Property(x => x.BankBranchId).HasColumnType("varchar(10)");
            builder.Property(x => x.UniqueReference).HasColumnType("varchar(20)");
            builder.Property(x => x.BankId).HasColumnType("varchar(3)");

            builder.Property(x => x.BranchPhoneNumber).HasColumnType("varchar(20)");
            builder.Property(x => x.BatchId).HasColumnType("varchar(20)");
            builder.Property(x => x.CbnAcct).HasColumnType("varchar(50)");
            builder.Property(x => x.Bvn).HasColumnType("varchar(11)");
            builder.Property(x => x.CollectedAmount).HasColumnType("DECIMAL(25, 2)");
            builder.Property(x => x.Currency).HasColumnType("varchar(3)");
            builder.Property(x => x.CustomerAccount).HasColumnType("varchar(50)");
            builder.Property(x => x.CustomerTin).HasColumnType("varchar(50)");
            builder.Property(x => x.CustomerPhoneNumber).HasColumnType("varchar(50)");
            builder.Property(x => x.CustomerEmail).HasColumnType("varchar(200)");
            builder.Property(x => x.CustomerName).HasColumnType("varchar(200)"); // Nibss 100
            builder.Property(x => x.Fee).HasColumnType("DECIMAL(25, 2)"); // man
            builder.Property(x => x.FeedType).HasColumnType("varchar(5)"); // man
            builder.Property(x => x.GifmisCode).HasColumnType("varchar(50)");
            builder.Property(x => x.LocationName).HasColumnType("varchar(100)");
            builder.Property(x => x.LocationCode).HasColumnType("varchar(20)");
            builder.Property(x => x.ItemName).HasColumnType("varchar(50)"); // man
            builder.Property(x => x.ItemCode).HasColumnType("varchar(50)"); // man
            builder.Property(x => x.MdaName).HasColumnType("varchar(max)"); // man
            builder.Property(x => x.MdaCode).HasColumnType("varchar(100)"); // man
            builder.Property(x => x.NarrationDescription).HasColumnType("varchar(200)"); // man
            builder.Property(x => x.payColDate).HasColumnType("Date"); // man
            builder.Property(x => x.PsspName).HasColumnType("varchar(200)");
            builder.Property(x => x.PsspCode).HasColumnType("varchar(20)"); // man
            builder.Property(x => x.RemittedAmount).HasColumnType("DECIMAL(25, 2)");
            builder.Property(x => x.RequestedAmount).HasColumnType("DECIMAL(25, 2)");
            builder.Property(x => x.SettlementRef).HasColumnType("varchar(50)"); // man
            builder.Property(x => x.SessionId).HasColumnType("Int");
            builder.Property(x => x.ValueDate).HasColumnType("Date");

            builder.Property(x => x.TsaPcCoderef).HasColumnType("varchar(100)");
            builder.Property(x => x.TsaPcCodename).HasColumnType("varchar(200)");
            builder.Property(x => x.Payer).HasColumnType("varchar(100)");

            builder.Property(x => x.RequestId).HasColumnType("varchar(100)");
           
            builder.Property(x => x.TransmittedDate).HasColumnType("varchar(100)");
            
            
           
            builder.Property(x => x.payColDate).HasColumnType("varchar(100)");
            builder.Property(x => x.Channel).HasColumnType("varchar(100)");

            builder.Property(x => x.checkerConfig.statusDescription).HasColumnType("varchar(100)");
            builder.Property(x => x.checkerConfig.StatusCode).HasColumnType("varchar(100)");
            builder.Property(x => x.checkerConfig.Initiatedby).HasColumnType("varchar(100)");
            builder.Property(x => x.checkerConfig.InitiatorBranch).HasColumnType("varchar(100)");
            builder.Property(x => x.checkerConfig.InitiatedDate).HasColumnType("Date");

            builder.Property(x => x.checkerConfig.Authorizedby).HasColumnType("varchar(100)");
            builder.Property(x => x.checkerConfig.AuthorizerComment).HasColumnType("varchar(100)");
            builder.Property(x => x.checkerConfig.IsAuthorized).HasColumnType("varchar(100)");
            builder.Property(x => x.checkerConfig.AuthorizedDate).HasColumnType("Date");
            builder.Property(x => x.checkerConfig.IsSuperAuthorized).HasColumnType("Bit");
            builder.Property(x => x.checkerConfig.SuperAuthorizerComment).HasColumnType("varchar(100)");
            builder.Property(x => x.checkerConfig.SuperAuthorizedby).HasColumnType("varchar(100)");
            builder.Property(x => x.checkerConfig.SuperAuthorizedDate).HasColumnType("Date");

        }
    }
}
