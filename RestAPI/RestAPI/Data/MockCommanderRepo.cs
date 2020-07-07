using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        private List<Command> commands;
        public MockCommanderRepo()
        {
            commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil An Egg", Line = "Boil Some Water", platform = "Do it Now" },
                new Command { Id = 1, HowTo = "Make Some Pizza", Line = "Hot The Pizza", platform = "Do it Now" },
                new Command { Id = 2, HowTo = "Buy a Cola", Line = "Put Some in Glass", platform = "Do it Now" }
        };
        }

        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            
        return commands;
        }

        public Command GetCommandById(int id)
        {
            return commands.FirstOrDefault(x => x.Id == id) ;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
