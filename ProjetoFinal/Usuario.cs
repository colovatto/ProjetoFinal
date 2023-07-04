using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal;

public partial class Usuario
{
    [Display(Name = "ID")]
    public int UserId { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Nome deve ser entre 3 ou 100 caracteres", MinimumLength = 3)]
    [Display(Name = "Nome Completo")]
    public string UserNome { get; set; } = null!;

    [Required]
    [StringLength(20, ErrorMessage = "Login deve ser entre 3 e 20 caracteres ", MinimumLength = 3)]
    [Display(Name = "Login")]
    public string UserLogin { get; set; } = null!;

    [Required]
    [StringLength(16, MinimumLength = 8)]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
    [Display(Name = "Senha")]
    public string UserSenha { get; set; } = null!;

    

}
