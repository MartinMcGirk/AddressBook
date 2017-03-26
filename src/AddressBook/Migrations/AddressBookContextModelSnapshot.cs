using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AddressBook.Models;

namespace AddressBook.Migrations
{
    [DbContext(typeof(AddressBookContext))]
    partial class AddressBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AddressBook.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("PostCode");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("TelephoneNumber");

                    b.HasKey("Id");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("AddressBook.Models.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessSector");

                    b.Property<int?>("ContactInfoId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ContactInfoId");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("AddressBook.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactInfoId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Firstname");

                    b.Property<string>("JobTitle");

                    b.Property<int?>("OrganisationId");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("ContactInfoId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("AddressBook.Models.Organisation", b =>
                {
                    b.HasOne("AddressBook.Models.ContactInfo", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId");
                });

            modelBuilder.Entity("AddressBook.Models.Person", b =>
                {
                    b.HasOne("AddressBook.Models.ContactInfo", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId");

                    b.HasOne("AddressBook.Models.Organisation")
                        .WithMany("Persons")
                        .HasForeignKey("OrganisationId");
                });
        }
    }
}
