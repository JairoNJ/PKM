using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public PokemonBase Base { get; set; }
    public int Level { get; set; }

    public int HP {  get; set; }

    public List<Move> Moves { get; set; }

    //Constructor
    public Pokemon(PokemonBase pBase, int pLevel)
    {
        Base = pBase;
        Level = pLevel;
        HP = MaxHp;

        //Generate Moves
        Moves = new List<Move>();
        foreach (var move in Base.LearnableMoves) {
            if(move.Level <= Level)
                Moves.Add(new Move(move.MoveBase));
            if(Moves.Count >= 4)
                break;
        }
    }

    //Se crean propiedades para cada una de los atributos del pokemon, y se aplica
    //la formula para aumentar las estadisticas en base al nivel del personaje.
    public int MaxHp 
    { 
        get { return Mathf.FloorToInt((Base.MaxHp * Level) /100f) +10 ; } 
    }
    public int Attack
    {
        get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5; }
    }
    public int Defense
    {
        get { return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5; }
    }
    public int SpAttack
    {
        get { return Mathf.FloorToInt((Base.SpAttack * Level) /100F) + 5; }
    }
    public int SpDefense
    {
        get { return Mathf.FloorToInt((Base.SpDefense * Level) / 100f) + 5; }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5; }
    }
}
