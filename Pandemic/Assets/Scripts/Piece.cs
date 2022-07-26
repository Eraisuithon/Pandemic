using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Vector3 position;
    public Dictionary<string, HashSet<string>> neighboors;
    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<RectTransform>().position;
        neighboors = new Dictionary<string, HashSet<string>>
        {
            {"Blue_Chicago", new HashSet<string>() {"Blue_Atlanta", "Blue_Montreal", "Blue_SanFrancisco"} },
            {"Blue_Montreal", new HashSet<string>() {"Blue_NewYork", "Blue_Washington", "Blue_Chicago"} },
            {"Blue_NewYork", new HashSet<string>() {"Blue_London", "Blue_Madrid", "Blue_Washington", "Blue_Montreal"} },
            {"Blue_Washington", new HashSet<string>() {"Blue_Atlanta", "Blue_NewYork", "Blue_Montreal", "Yellow_Miami"} },
            {"Blue_Atlanta", new HashSet<string>() { "Blue_Chicago", "Blue_Washington", "Yellow_Miami" } },
            {"Blue_SanFrancisco", new HashSet<string>() {"Blue_Chicago", "Red_Tokyo", "Red_Manila"} },
            {"Blue_London", new HashSet<string>() {"Blue_Paris", "Blue_Madrid", "Blue_Essen", "Blue_NewYork"} },
            {"Blue_Paris", new HashSet<string>() {"Blue_Milan", "Blue_Essen", "Blue_London", "Blue_Madrid", "Black_Algiers"} },
            {"Blue_Milan", new HashSet<string>() {"Blue_Essen", "Blue_Paris", "Black_Instanbul"} },
            {"Blue_Essen", new HashSet<string>() {"Blue_Milan", "Blue_StPetersburg", "Blue_Paris", "Blue_London"} },
            {"Blue_StPetersburg", new HashSet<string>() {"Blue_Essen", "Black_Instanbul", "Black_Moscow"} },
            {"Blue_Madrid", new HashSet<string>() {"Blue_Paris", "Yellow_SaoPaulo", "Black_Algiers", "Blue_London", "Blue_NewYork"} },
            {"Yellow_LosAngeles", new HashSet<string>() {"Yellow_MexicoCity", "Blue_Chicago", "Blue_SanFrancisco", "Red_Sydney"} },
            {"Yellow_MexicoCity", new HashSet<string>() {"Yellow_LosAngeles", "Blue_Chicago", "Yellow_Miami", "Yellow_Bogota", "Yellow_Lima"} },
            {"Yellow_Miami", new HashSet<string>() { "Yellow_MexicoCity", "Yellow_Bogota", "Blue_Atlanta", "Blue_Washington" } },
            {"Yellow_Bogota", new HashSet<string>() { "Yellow_Miami", "Yellow_MexicoCity", "Yellow_Lima", "Yellow_BuenosAires", "Yello_SaoPaulo" } },
            {"Yellow_Lima", new HashSet<string>() { "Yellow_Santiago", "Yellow_Bogota", "Yellow_MexicoCity" } },
            {"Yellow_Santiago", new HashSet<string>() { "Yellow_Lima" } },
            {"Yellow_BuenosAires", new HashSet<string>() { "Yellow_SaoPaulo", "Yellow_Bogota" } },
            {"Yellow_SaoPaulo", new HashSet<string>() { "Yellow_Bogota", "Yellow_BuenosAires", "Blue_Madrid",  "Yellow_Lagos"} },
            {"Yellow_Lagos", new HashSet<string>() {"Yellow_SaoPaulo", "Yellow_Kinsasa", "Yellow_Khartoum"} },
            {"Yellow_Kinshasa", new HashSet<string>() {"Yellow_Lagos", "Yellow_Khartoum", "Yellow_Johannesburg"} },
            {"Yellow_Johannesburg", new HashSet<string>() {"Yellow_Kinsasa", "Yellow_Khartoum"} },
            {"Yellow_Khartoum", new HashSet<string>() {"Yellow_Kinsasa", "Yellow_Johannesburg", "Yellow_Lagos"} },
            {"Black_Instanbul", new HashSet<string>() {"Black_Algiers", "Black_Cairo", "Black_Baghdad", "Black_Moscow", "Blue_StPetersburg", "Blue_Milan"} },
            {"Black_Algiers", new HashSet<string>() {"Blue_Madrid", "Blue_Paris", "Black_Instanbul", "Black_Cairo"} },
            {"Black_Cairo", new HashSet<string>() {"Black_Algiers", "Black_Instanbul", "Black_Baghdad", "Black_Riyadh"} },
            {"Black_Baghdad", new HashSet<string>() {"Black_Instanbul", "Black_Cairo", "Black_Riyadh", "Black_Karachi", "Black_Tehran"} },
            {"Black_Riyadh", new HashSet<string>() {"Black_Cairo", "Black_Baghdad", "Black_Karachi"} },
            {"Black_Moscow", new HashSet<string>() {"Blue_StPetersburg", "Black_Instanbul", "Black_Tehran"} },
            {"Black_Tehran", new HashSet<string>() {"Black_Moscow", "Black_Baghdad", "Black_Karachi", "Black_Delhi"} },
            {"Black_Karachi", new HashSet<string>() {"Black_Riyadh", "Black_Baghdad", "Black_Tehran", "Black_Delhi", "Black_Mumbai"} },
            {"Black_Delhi", new HashSet<string>() {"Black_Tehran", "Black_Karachi", "Black_Mumbai", "Black_Chennai", "Black_Kolkata"} },
            {"Black_Kolkata", new HashSet<string>() {"Black_Delhi", "Black_Chennai", "Red_Bangkok", "Red_HongKong"} },
            {"Black_Mumbai", new HashSet<string>() {"Black_Karachi", "Black_Delhi", "Black_Chennai"} },
            {"Black_Chennai", new HashSet<string>() {"Black_Mumbai", "Black_Delhi", "Black_Kolkata", "Red_Bangkok", "Red_Jakarta"} },
            {"Red_Bangkok", new HashSet<string>() {"Black_Chennai", "Black_Kolkata", "Red_HongKong", "Red_HoChiMinHCity", "Red_Jakarta"} },
            {"Red_Jakarta", new HashSet<string>() {"Black_Chennai", "Red_Bangkok", "Red_HoChiMinhCity", "Red_Sydney"} },
            {"Red_HoChiMinhCity", new HashSet<string>() {"Red_Jakarta", "Red_Bangkok", "Red_HongKong", "Red_Manila"} },
            {"Red_Manila", new HashSet<string>() {"Red_HoChiMinhCity", "Red_Taipei", "Red_HongKong", "Red_Sydney", "Blue_SanFransisco"} },
            {"Red_HongKong", new HashSet<string>() {"Black_Kolkata", "Red_Bangkok", "Red_HoChiMinhCity", "Red_Manila", "Red_Taipei", "Red_Shanghai"} },
            {"Red_Taipei", new HashSet<string>() {"Red_HongKong", "Red_Shanghai", "Red_Osaka", "Red_Manila"} },
            {"Red_Shanghai", new HashSet<string>() {"Red_HongKong", "Red_Beijing", "Red_Seoul", "Red_Tokyo", "Red_Taipei"} },
            {"Red_Beijing", new HashSet<string>() {"Red_Shanghai", "Red_Seoul"} },
            {"Red_Seoul", new HashSet<string>() {"Red_Beijing", "Red_Shanghai", "Red_Tokyo"} },
            {"Red_Tokyo", new HashSet<string>() {"Red_Seoul", "Red_Shanghai", "Red_Osaka", "Blue_SanFransisco"} },
            {"Red_Osaka", new HashSet<string>() {"Red_Tokyo", "Red_Taipei"} },
            {"Red_Sydney", new HashSet<string>() {"Red_Jakarta", "Red_Manila", "Yellow_LosAngeles"} },
        };
    }
}
