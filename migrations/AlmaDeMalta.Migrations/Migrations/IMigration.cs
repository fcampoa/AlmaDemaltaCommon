using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaDeMalta.Migrations.Migrations
{
    public interface IMigration
    {
        Task Execute();
    }
}
