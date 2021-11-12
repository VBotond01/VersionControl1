using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstraction;
using week08.Abstractions;

namespace week08.Entities
{
    public class CarFactory : IToyFactory
    {
        public Car CreateNew()
        {
            return new Car();

        }

        Toy IToyFactory.CreateNew()
        {
            throw new NotImplementedException();
        }
    }
}
