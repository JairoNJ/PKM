using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName ="Pokemon/Create new pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] string pokemonName;

    [TextArea] 
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    //Base stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    //Lista de movimientos que puede aprender un pokemon
    [SerializeField] List<LearnableMove> learnableMoves;

    //Las propiedades en C# encapsulan datos.
    //Usan get y set para controlar el acceso y modificaci�n
    //de variables privadas. Esto ayuda a proteger tu c�digo.
    //Evitas vulnerabilidades y controlas c�mo se accede a las variables.
    //As�, mantienes la integridad de los datos y puedes a�adir validaciones si es necesario.
    public string Name { get{ return pokemonName;} }
    public string Description { get { return description; } }
    public Sprite FrontSprite { get { return frontSprite;} }
    public Sprite BackSprite { get { return backSprite;} }
    public PokemonType Type1 { get { return type1; } }
    public PokemonType Type2 { get {  return type2; } }
    public int MaxHp { get {  return maxHp; } }
    public int Attack { get { return attack; } }
    public int Defense { get {  return defense; } }
    public int SpAttack { get {  return spAttack; } }
    public int SpDefense { get { return spDefense; } }
    public int Speed { get { return speed; } }

    //Propiedad para la lista que contendra todos los movimientos que puede aprender el pokemon
    public List<LearnableMove> LearnableMoves { get { return learnableMoves; } }
}

//Moviemiento que se puede aprender
//Esta clase debe ser [SerializeField] para poderla ver en el inspector
[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;       //Moviemiento que se aprendera
    [SerializeField] int level;               //Nivel en el cual aprendera el movimiento.}

    public MoveBase MoveBase { get { return moveBase; } }
    public int Level { get { return level; } }
}

public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Dark,
    Steel,
    Fairy

}
