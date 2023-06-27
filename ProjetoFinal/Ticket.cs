using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal;

public partial class Ticket
{
    [Display(Name = "Chamado")]
    public int TicketId { get; set; }

    [Display(Name = "Nome")]
    public string TicketNome { get; set; } = null!;

    [Display(Name = "Email")]
    public string TicketEmail { get; set; } = null!;

    [Display(Name = "Telefone / Ramal")]
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
