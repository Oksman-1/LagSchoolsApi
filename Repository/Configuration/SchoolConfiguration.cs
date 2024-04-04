using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
	public void Configure(EntityTypeBuilder<School> builder)
	{
		builder.HasData
		(
			new School
			{
				SchoolId = 1,
				SchoolName = "Vinefield School",
				SchoolAddress = "21, Sinari Daramijo, Victoria Island, Lagos Nigeria",
				PhoneNumber = "016403300",
				Email = "vinefields_sch@gmail.com",
				Website = "https://www.vinefield.com/",
				SchoolLocation = "Victoria Island",
				SchoolAreaCode = "VI/03",
				DateOpened = new DateTime(1988,02,29),
				SchoolType = SchoolType.Mixed,
				LandArea = 2310.345,
				SecurityLevel = SecurityLevel.Excellent,
				WAECApproved = true,
				DateWAECApproved = new DateTime(1990,03,12),
				SchoolBus = true,
				NumberSchoolBus = 6,
				SchoolDescription = "Vinefield School is an advanced educational institution sited in Victoria Island renowned for delivering qualitative and sound educational program in a conducive environment.",
				SummarySchoolFacilities = "Library,Gymnasium,Swimming Pool,laboratories,School Hall,Hostels"	

			},
			new School
			{
				SchoolId = 2,
				SchoolName = "White Dove High School",
				SchoolAddress = "The White Dove Drive, Off Monastery Road, By New Road Bus Stop, Km 47 Lekki-Epe Expressway, Lekki- Ajah, Lagos Nigeria",
				PhoneNumber = "015412680",
				Email = "white_dove@gmail.com",
				Website = "https://www.whitedove.com/",
				SchoolLocation = "Lekki Ajah",
				SchoolAreaCode = "LA/07",
				DateOpened = new DateTime(1998, 05, 01),
				SchoolType = SchoolType.Mixed,
				LandArea = 1310.345,
				SecurityLevel = SecurityLevel.Average,
				WAECApproved = true,
				DateWAECApproved = new DateTime(2001, 03, 12),
				SchoolBus = true,
				NumberSchoolBus = 2,
				SchoolDescription = "White Dove High School is an educational institution providing outstanding all-round education of international standard while encouraging leadership qualities such as high moral standards, truthfulness, determination, hard-work, diligence and integrity.",
				SummarySchoolFacilities = "Library,laboratories,School Hall,Hostels"

			},
			new School
			{
				SchoolId = 3,
				SchoolName = "Wisdom Gate High School",
				SchoolAddress = "4-6 Odegbami Street, Off Adeniyi Jones Avenue, Ikeja, Lagos Nigeria",
				PhoneNumber = "010025680",
				Email = "wisdomgate01@gmail.com",
				Website = "https://www.wisdom_gate.com/",
				SchoolLocation = "Ikeja",
				SchoolAreaCode = "IKJ/02",
				DateOpened = new DateTime(1983, 10, 27),
				SchoolType = SchoolType.Day,
				LandArea = 1762.209,
				SecurityLevel = SecurityLevel.Good,
				WAECApproved = true,
				DateWAECApproved = new DateTime(1985, 08, 22),
				SchoolBus = true,
				NumberSchoolBus = 4,
				SchoolDescription = "Wisdom Gate High School provides professional secondary educational services in lkeja.",
				SummarySchoolFacilities = "Library,laboratories,School Hall"
			}
		); 
	}

}
