using System.ComponentModel.DataAnnotations;

namespace Simple.ViewModels.Students
{
    public class UpdateStudentViewModel
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório"),
         MinLength(length: 3, ErrorMessage = "Tamanho mínimo de caracteres é 3"),
         MaxLength(length: 50, ErrorMessage = "Tamanho máximo de caracteres é 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Idade é obrigatória"),
         Range(5, 50, ErrorMessage = "Mínimo de idade é 5 e Máximo de idade é 50")]
        public ushort Age { get; set; }
    }
}
