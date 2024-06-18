using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Pmodels
    {
      
        public int Id { get; set; }
        [Required]
        public string? First_Name { get; set; }
        [Required]
        public string? Last_Name { get; set; }
        
        public int Phone_Number { get; set; }
        

    }


    public class DModels
    {
            [Key]
            public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Specialization { get; set; }


        }
        public class AModels
        {
            [Key]
            public int Id { get; set; }
        [Required]
        public string? Doctor_Name { get; set; }
        [Required]
        public string? Patient_Name {  get; set; }
        [Required]

        public DateTime date { get; set; }


        }
        public class MModels
        {
            [Key]
            public int Id { get; set; }
        [Required]
        public string?  PatientName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? DiaGnosis { get; set; }
        [Required]
        public string? Medications { get; set; }



        }


        
    public class Pdatabase : DbContext
    {
        public Pdatabase(DbContextOptions<Pdatabase>options):base(options)
        {
            
        }
        public DbSet<Pmodels> Patient_Details { get; set; }
        public DbSet<DModels> Doctor_Details { get; set; }
        public DbSet<AModels> Appointment_Details { get; set; }
        public DbSet<MModels> Medical_Records { get; set; }
    }
    
}
