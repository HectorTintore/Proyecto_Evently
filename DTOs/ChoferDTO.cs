using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Transactions;

namespace Proyecto_Evently.DTOs;

public class ChoferDTO
{
    public int IdChofer { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Gmail { get; set; }
    public string NumeroTelefono { get; set; }

    
}