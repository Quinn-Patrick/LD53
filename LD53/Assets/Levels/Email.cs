using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Email", menuName ="Data/Email", order =1)]
public class Email : ScriptableObject
{
    public string From;
    public string Subject;
    public string Body;
}
