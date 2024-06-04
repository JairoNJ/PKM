using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase contendra los datos que varian durante el juego, por ejemplo los pp, Los Power Points (cuántas veces se puede usar el movimiento)
public class Move
{
    public MoveBase Base { get; set; }
    public int PP { get; set; }

    //Constructor
    public Move (MoveBase pBase)
    {
        Base = pBase;
        PP = pBase.PP;
    }

}
