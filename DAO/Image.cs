using System;
using System.Collections.Generic;

namespace MTControl.DAO;

public partial class Image
{
    public int Id { get; set; }

    public string Src { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Alt { get; set; } = null!;
}
