using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal;

public partial class Ticket
{
    [Display(Name = "Ticket")]
    public int TicketId { get; set; }

    [Display(Name = "Nome")]
    public string TicketNome { get; set; } = null!;

    [Display(Name = "Email")]
    public string TicketEmail { get; set; } = null!;

    [Display(Name = "Telefone / Ramal")]   
    [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{4})$", ErrorMessage = "Telefone não é valido")]
    public string TicketTel { get; set; } = null!;

    [Display(Name = "Horário de Trabalho")]
    public string TicketHora { get; set; } = null!;

    [Display(Name = "Evidência")]
    public byte[]? TicketEvidencia { get; set; }

    [Display(Name = "Cetegoria")]
    public string TicketCategoria { get; set; } = null!;

    [Display(Name = "Descrição")]
    public string TicketDescricao { get; set; } = null!;
}
