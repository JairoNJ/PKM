using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlePokemon : MonoBehaviour
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerPokemon;

    public Pokemon Pokemon {  get;  set; }
    public void Setup()
    {
        Pokemon = new Pokemon(_base, level);
        if(isPlayerPokemon)
            GetComponent<Image>().sprite = Pokemon.Base.BackSprite;
        else
            GetComponent<Image>().sprite = Pokemon.Base.FrontSprite;
        
    }
}
