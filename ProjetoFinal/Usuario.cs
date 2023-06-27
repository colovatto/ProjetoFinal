using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal;

public partial class Usuario
{
    public int UserId { get; set; }

    [Display(Name = "Nome")]
    public string UserNome { get; set; } = null!;

    [Display(Name = "Login")]
    public string UserLogin { get; set; } = null!;

    [Display(Name = "Senha")]
    public string UserSenha { get; set; } = null!;
}
