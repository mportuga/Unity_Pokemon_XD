using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public List<OwnedPokemon> ownedPokemon = new List<OwnedPokemon>();
	public string initialDir = Direction.South.ToString ();

	void Start () {
	
	}
	
	void Update () {
	
	}
}

[System.Serializable]
public class OwnedPokemon
{
    public string NickName;
    public BasePokemon pokemon;
    public int level;
    public List<PokemonMoves> moves = new List<PokemonMoves>();
}