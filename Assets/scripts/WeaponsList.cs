using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponsList : MonoBehaviour {

    public int numOfWeapons;

    public List<GameObject> Weapons;
    public List<GameObject> AvailableWeapons;

    public List<Transform> AvailableSpawns;

    public int seed = 42;

	void Start () {
		AvailableWeapons = Weapons;
        GenerateWeapons(numOfWeapons);
	}

    void GenerateWeapons(int num)
    {
        Random.seed = seed;

        for(int i = 0; i < num; i++)
        {
            int randWeapon = (int)Random.Range(0, AvailableWeapons.Count - 1);
            int randSpawn = (int)Random.Range(0, AvailableSpawns.Count - 1);
			Debug.Log(AvailableWeapons[randWeapon].name);
			Instantiate(AvailableWeapons[randWeapon], AvailableSpawns[randSpawn].position, Quaternion.identity);
            AvailableWeapons.Remove(AvailableWeapons[randWeapon]);
            AvailableSpawns.Remove(AvailableSpawns[randSpawn]);
        }
    }
}
