using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    public class Candidat
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string NiveauEtude { get; set; }
        public string Experience { get; set; }
        public string DernierEmpl { get; set; }
        public string CV { get; set; }  
    }
}
