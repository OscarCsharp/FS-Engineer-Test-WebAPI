using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface IApiConsume
    {
       Task<List<string>> Jokes();
       Task<People> Person(string category);
       Task<Object> getPeople();
    }
}
