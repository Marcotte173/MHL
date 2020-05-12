using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ComputerTeam:Team
{
    List<string> locations = new List<string>
    {
        "Winnepeg", "Guelph", "Amsterdam", "Toronto",
        "New Zealand", "Calgary", "St. Paul"
    };
    List<string> names = new List<string>
    {
        "Saints", "Worriers", "Goombas", "Poops",
        "Jerks",  "Turkeys", "Suckas"
    };
    public ComputerTeam()
    : base()
    {
        money = (350000 + Utilities.RandomInt(-20000, 50000)) * Utilities.difficulty;
        fans = (100 + Utilities.RandomInt(-20, 100)) * Utilities.difficulty;
        reputation = (100 + Utilities.RandomInt(-5, 20)) * Utilities.difficulty;
        int locationRoll = Utilities.RandomInt(0, locations.Count);
        string location = locations[locationRoll];
        locations.Remove(locations[locationRoll]);
        int nameRoll = Utilities.RandomInt(0, names.Count);
        string teamName = names[nameRoll];
        names.Remove(names[nameRoll]);
        gmName = Create.nameList[Utilities.RandomInt(0, Create.nameList.Count)];
        name = $"The {location} {teamName}";
        Create.nameList.Remove(name);
        locations.Remove(location);
        names.Remove(teamName);
    }
}