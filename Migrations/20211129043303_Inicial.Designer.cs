// <auto-generated />
using BusFinder_2.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BusFinder_2.Migrations
{
    [DbContext(typeof(BusFinderContext))]
    [Migration("20211129043303_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BusFinder_2.Models.Arduino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Hora")
                        .HasColumnType("integer");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<int>("Minuto")
                        .HasColumnType("integer");

                    b.Property<int>("Segundo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Arduinos");
                });

            modelBuilder.Entity("BusFinder_2.Models.Itinerario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Fim")
                        .HasColumnType("text");

                    b.Property<string>("Horario")
                        .HasColumnType("text");

                    b.Property<string>("Inicio")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Itinerarios");
                });

            modelBuilder.Entity("BusFinder_2.Models.ItinerarioVeiculo", b =>
                {
                    b.Property<int>("VeiculoId")
                        .HasColumnType("integer");

                    b.Property<int>("ItinerarioId")
                        .HasColumnType("integer");

                    b.HasKey("VeiculoId", "ItinerarioId");

                    b.HasIndex("ItinerarioId");

                    b.ToTable("ItinerarioVeiculo");
                });

            modelBuilder.Entity("BusFinder_2.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.Property<double>("Telefone")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BusFinder_2.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ArduinoId")
                        .HasColumnType("integer");

                    b.Property<string>("Placa")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArduinoId")
                        .IsUnique();

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("BusFinder_2.Models.ItinerarioVeiculo", b =>
                {
                    b.HasOne("BusFinder_2.Models.Itinerario", "Itinerario")
                        .WithMany("ItinerarioVeiculo")
                        .HasForeignKey("ItinerarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusFinder_2.Models.Veiculo", "Veiculo")
                        .WithMany("ItinerarioVeiculo")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Itinerario");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("BusFinder_2.Models.Veiculo", b =>
                {
                    b.HasOne("BusFinder_2.Models.Arduino", "Arduino")
                        .WithOne("Veiculo")
                        .HasForeignKey("BusFinder_2.Models.Veiculo", "ArduinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arduino");
                });

            modelBuilder.Entity("BusFinder_2.Models.Arduino", b =>
                {
                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("BusFinder_2.Models.Itinerario", b =>
                {
                    b.Navigation("ItinerarioVeiculo");
                });

            modelBuilder.Entity("BusFinder_2.Models.Veiculo", b =>
                {
                    b.Navigation("ItinerarioVeiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
