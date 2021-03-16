using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapper.Shared.Commands
{
    public interface ICommand
    {
        bool Valid();
    }
}
