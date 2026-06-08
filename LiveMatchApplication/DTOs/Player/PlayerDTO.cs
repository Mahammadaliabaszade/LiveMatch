using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Application.DTOs.Player;

public class PlayerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public int Number { get; set; }
    public string Nationality { get; set; }
    public int Age { get; set; }
    public string Photo { get; set; }
    public string TeamName { get; set; }
}