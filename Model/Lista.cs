using System.ComponentModel.DataAnnotations;

namespace TO_DO_LIST.Model
{
    public class Lista
    {

        public int id { get; set; }

        [Required]
        public string titulo { get; set; }
        public string tarea { get; set; }
        public bool tareaC { get; set; }
       
        


    }
}
