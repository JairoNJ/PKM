using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create new move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string nameMovement;         // El nombre del movimiento
    [TextArea]
    [SerializeField] string description;  // La descripci�n del movimiento
    [SerializeField] PokemonType type;    // El tipo del movimiento (por ejemplo, Fuego, Agua, etc.)
    [SerializeField] int power;           // La potencia del movimiento (cu�nto da�o hace)
    [SerializeField] int accuracy;        // La precisi�n del movimiento (probabilidad de acertar)
    [SerializeField] int pp;              // Los Power Points (cu�ntas veces se puede usar el movimiento)

    public string NameMovement { get { return nameMovement; } }
    public string Description { get { return description; } }
    public PokemonType Type { get {  return type; } }       
    public int Power { get { return power; } } 
    public int Accuracy { get { return accuracy; } }
    public int PP {  get { return pp; } }

}
