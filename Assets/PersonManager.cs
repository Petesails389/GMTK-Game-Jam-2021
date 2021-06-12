using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class PersonManager : ScriptableObject
{
    List<Person> persons = new List<Person>();

    void OnEnable()
    {
        persons.Clear();
    }

    public void AddPerson(Person _person)
    {
        persons.Add(_person);
    }

    public List<Person> GetPersons()
    {
        return persons;
    }

}
