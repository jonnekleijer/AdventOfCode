using System.ComponentModel;

namespace Day9;

enum Direction
{
    [Description("Up")]
    U = 1,
    [Description("Right")]
    R = 2,
    [Description("Down")]
    D = 3,
    [Description("Left")]
    L = 4,

    [Description("Up Right")]
    UR = 5,
    [Description("Up Left")]
    UL = 6,
    [Description("Down Right")]
    DR = 7,
    [Description("Down Left")]
    DL = 8
}
