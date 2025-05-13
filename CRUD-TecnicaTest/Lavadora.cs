using System;
using System.Collections.Generic;

namespace CRUD_TecnicaTest;

public partial class Lavadora
{
    public int Id { get; set; }

    public string? Brand { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
