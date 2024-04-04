using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
	public void Configure(EntityTypeBuilder<Class> builder)
	{
		builder.HasData
		(
		new Class
		{
			ClassId = 1,
			ClassDesignation = Classes.JSS1,
			ClassName = "JSS1",
			HeadClassTeacherName = "Mr Ifeanyi Eboigbe",
			NumberOfArms = 5,
			ClassSize = 231.108,
			SchoolId = 1			
		},
		new Class
		{
			ClassId = 2,
			ClassDesignation = Classes.JSS3,
			ClassName = "JSS3",
			HeadClassTeacherName = "Mrs Dapo Oguniyi",
			NumberOfArms = 6,
			ClassSize = 231.108,
			SchoolId = 1
		},
		new Class
		{
			ClassId = 3,
			ClassDesignation = Classes.SS1,
			ClassName = "SS1",
			HeadClassTeacherName = "Mr Felix Okafor",
			NumberOfArms = 6,
			ClassSize = 231.108,
			SchoolId = 1
		}


		);
	}

}
